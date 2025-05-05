import React, { useState, useEffect } from "react";
import axios from "axios";
import './Bodegas.css';

const Bodegas = () => {
  const token = localStorage.getItem("token");

  const [bodegas, setBodegas] = useState([]);
  const [bodegaActual, setBodegaActual] = useState({
    id: null,
    nombre: "",
    direccion: "",
    ciudad: ""
  });

  const [mensaje, setMensaje] = useState("");
  const [error, setError] = useState("");

  const cargarBodegas = () => {
    axios.get("https://localhost:7005/api/Bodegas", {
      headers: { Authorization: `Bearer ${token}` }
    })
    .then(res => setBodegas(res.data))
    .catch(err => setError("Error al cargar bodegas"));
  };

  useEffect(() => {
    cargarBodegas();
  }, []);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setBodegaActual({ ...bodegaActual, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const headers = {
      Authorization: `Bearer ${token}`,
      "Content-Type": "application/json"
    };

    const bodegaParaEnviar = { ...bodegaActual };
    if (!bodegaParaEnviar.id) delete bodegaParaEnviar.id;

    const url = bodegaActual.id
      ? `https://localhost:7005/api/Bodegas/${bodegaActual.id}`
      : "https://localhost:7005/api/Bodegas";

    const metodo = bodegaActual.id ? axios.put : axios.post;

    metodo(url, bodegaParaEnviar, { headers })
      .then(() => {
        setMensaje("guardado correctamente");
        setBodegaActual({ id: null, nombre: "", direccion: "", ciudad: "" });
        cargarBodegas();
      })
      .catch(() => setError("Error al guardar"));
  };

  const seleccionarBodegaParaEditar = (bodega) => {
    setBodegaActual(bodega);
    setMensaje("");
    setError("");
  };

  const eliminarBodega = (id) => {
    axios.delete(`https://localhost:7005/api/Bodegas/${id}`, {
      headers: { Authorization: `Bearer ${token}` }
    })
    .then(() => cargarBodegas())
    .catch(() => setError("Error al eliminar"));
  };

  return (
    <div className="container">
      <h2>Gestión de Bodegas</h2>

      {mensaje && <div className="success">{mensaje}</div>}
      {error && <div className="error">{error}</div>}

      <form onSubmit={handleSubmit}>
        <input type="text" name="nombre" placeholder="Nombre" value={bodegaActual.nombre} onChange={handleChange} required />
        <input type="text" name="direccion" placeholder="Direccion" value={bodegaActual.direccion} onChange={handleChange} required />
        <input type="text" name="ciudad" placeholder="Ciudad" value={bodegaActual.ciudad} onChange={handleChange} required />
        <button type="submit">{bodegaActual.id ? "Actualizar" : "Guardar"}</button>
      </form>

      <table>
        <thead>
          <tr>
            <th>Nombre</th>
            <th>direccion</th>
            <th>ciudad</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {bodegas.map((bod) => (
            <tr key={bod.id}>
              <td>{bod.nombre}</td>
              <td>{bod.direccion}</td>
              <td>{bod.ciudad}</td>
              <td>
                <button className="btn-editar" onClick={() => seleccionarBodegaParaEditar(bod)}>Editar</button>
                <button className="btn-eliminar" onClick={() => eliminarBodega(bod.id)}>Eliminar</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Bodegas; 
