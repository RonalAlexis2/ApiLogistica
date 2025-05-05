import { useEffect, useState } from "react";
import axios from "axios";
import './Clientes.css';



function Clientes() {

 const token = localStorage.getItem("token");
  const [clientes, setClientes] = useState([]);
  const [clienteActual, setClienteActual] = useState({
    id: null,
    nombre: "",
    documento: "",
    direccion: "",
    telefono: ""
  });
  const [error, setError] = useState("");
  const [mensaje, setMensaje] = useState("");

  

  const cargarClientes = () => {
    axios.get("https://localhost:7005/api/Clientes", {
      headers: { Authorization: `Bearer ${token}` }
    })
      .then((res) => setClientes(res.data))
      .catch((err) => {
        console.error(err);
        setError("Error al cargar clientes");
      });
  };

  useEffect(() => {
    cargarClientes();
  }, []);

  const handleChange = (e) => {
    setClienteActual({
      ...clienteActual,
      [e.target.name]: e.target.value
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
  
    const headers = {
      Authorization: `Bearer ${token}`,
      "Content-Type": "application/json"
    };
  
    // Clonamos el cliente y removemos el id si es nuevo
    const clienteParaEnviar = { ...clienteActual };
    if (!clienteParaEnviar.id) {
      delete clienteParaEnviar.id; // 🔥 esto es clave
    }
  
    if (clienteActual.id) {
      axios.put(`https://localhost:7005/api/Clientes/${clienteActual.id}`, clienteParaEnviar, { headers })
        .then(() => {
          setMensaje("Cliente actualizado exitosamente");
          setClienteActual({ id: null, nombre: "", documento: "", direccion: "", telefono: "" });
          cargarClientes();
        })
        .catch((err) => {
          console.error(err);
          setError("Error al actualizar cliente");
        });
    } else {
      axios.post("https://localhost:7005/api/Clientes", clienteParaEnviar, { headers })
        .then(() => {
          setMensaje("Cliente agregado exitosamente");
          setClienteActual({ id: null, nombre: "", documento: "", direccion: "", telefono: "" });
          cargarClientes();
        })
        .catch((err) => {
          console.error(err);
          setError("Error al agregar cliente");
        });
    }
  };

  const seleccionarClienteParaEditar = (cliente) => {
    setClienteActual(cliente);
    setMensaje("");
    setError("");
  };

  const eliminarCliente = (id) => {
    if (!window.confirm("¿Seguro que deseas eliminar este cliente?")) return;

    axios.delete(`https://localhost:7005/api/Clientes/${id}`, {
      headers: { Authorization: `Bearer ${token}` }
    })
      .then(() => {
        setMensaje("Cliente eliminado exitosamente");
        cargarClientes();
      })
      .catch((err) => {
        console.error(err);
        setError("Error al eliminar cliente");
      });
  };

  return (
    <div className="container">
    <h2>Gestión de Clientes</h2>
  
    {mensaje && <div className="success">{mensaje}</div>}
    {error && <div className="error">{error}</div>}
  
    <form onSubmit={handleSubmit}>
      <input type="text" name="nombre" placeholder="Nombre" value={clienteActual.nombre} onChange={handleChange} required />
      <input type="text" name="documento" placeholder="Documento" value={clienteActual.documento} onChange={handleChange} required />
      <input type="text" name="direccion" placeholder="Dirección" value={clienteActual.direccion} onChange={handleChange} required />
      <input type="text" name="telefono" placeholder="Teléfono" value={clienteActual.telefono} onChange={handleChange} required />
      <button type="submit">{clienteActual.id ? "Actualizar" : "Guardar"}</button>
    </form>
  
    <table>
      <thead>
        <tr>
          <th>Nombre</th>
          <th>Documento</th>
          <th>Dirección</th>
          <th>Teléfono</th>
          <th>Acciones</th>
        </tr>
      </thead>
      <tbody>
        {clientes.map((cliente) => (
          <tr key={cliente.id}>
            <td>{cliente.nombre}</td>
            <td>{cliente.documento}</td>
            <td>{cliente.direccion}</td>
            <td>{cliente.telefono}</td>
            <td>
              <button className="btn-editar" onClick={() => seleccionarClienteParaEditar(cliente)}>Editar</button>
              <button className="btn-eliminar" onClick={() => eliminarCliente(cliente.id)}>Eliminar</button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  </div>
  
  );
}

export default Clientes;
