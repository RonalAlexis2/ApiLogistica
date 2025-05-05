import React, { useState, useEffect } from "react";
import axios from "axios";
import './Productos.css';

const Productos = () => {
  const token = localStorage.getItem("token");

  const [productos, setProductos] = useState([]);
  const [productoActual, setProductoActual] = useState({
    id: null,
    nombre: "",
    descripcion: "",
    peso: 0
  });

  const [mensaje, setMensaje] = useState("");
  const [error, setError] = useState("");

  const cargarProductos = () => {
    axios.get("https://localhost:7005/api/Productoes", {
      headers: { Authorization: `Bearer ${token}` }
    })
    .then(res => setProductos(res.data))
    .catch(err => setError("Error al cargar productos"));
  };

  useEffect(() => {
    cargarProductos();
  }, []);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setProductoActual({ ...productoActual, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const headers = {
      Authorization: `Bearer ${token}`,
      "Content-Type": "application/json"
    };

    const productoParaEnviar = { ...productoActual };
    if (!productoParaEnviar.id) delete productoParaEnviar.id;

    const url = productoActual.id
      ? `https://localhost:7005/api/Productoes/${productoActual.id}`
      : "https://localhost:7005/api/Productoes";

    const metodo = productoActual.id ? axios.put : axios.post;

    metodo(url, productoParaEnviar, { headers })
      .then(() => {
        setMensaje("Producto guardado correctamente");
        setProductoActual({ id: null, nombre: "", descripcion: "", peso: 0 });
        cargarProductos();
      })
      .catch(() => setError("Error al guardar producto"));
  };

  const seleccionarProductoParaEditar = (producto) => {
    setProductoActual(producto);
    setMensaje("");
    setError("");
  };

  const eliminarProducto = (id) => {
    axios.delete(`https://localhost:7005/api/Productoes/${id}`, {
      headers: { Authorization: `Bearer ${token}` }
    })
    .then(() => cargarProductos())
    .catch(() => setError("Error al eliminar producto"));
  };

  return (
    <div className="container">
      <h2>Gestión de Productos</h2>

      {mensaje && <div className="success">{mensaje}</div>}
      {error && <div className="error">{error}</div>}

      <form onSubmit={handleSubmit}>
        <input type="text" name="nombre" placeholder="Nombre" value={productoActual.nombre} onChange={handleChange} required />
        <input type="text" name="descripcion" placeholder="Descripción" value={productoActual.descripcion} onChange={handleChange} required />
        <input type="number" name="peso" placeholder="Peso (kg)" value={productoActual.peso} onChange={handleChange} required />
        <button type="submit">{productoActual.id ? "Actualizar" : "Guardar"}</button>
      </form>

      <table>
        <thead>
          <tr>
            <th>Nombre</th>
            <th>Descripción</th>
            <th>Peso</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {productos.map((prod) => (
            <tr key={prod.id}>
              <td>{prod.nombre}</td>
              <td>{prod.descripcion}</td>
              <td>{prod.peso}</td>
              <td>
                <button className="btn-editar" onClick={() => seleccionarProductoParaEditar(prod)}>Editar</button>
                <button className="btn-eliminar" onClick={() => eliminarProducto(prod.id)}>Eliminar</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Productos; 
