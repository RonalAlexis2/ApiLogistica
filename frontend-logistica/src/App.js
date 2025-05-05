import React, { useEffect } from "react";
import { BrowserRouter as Router, Route, Routes, Link } from "react-router-dom";
import Clientes from "./components/Clientes";
import Productos from "./components/Productos";
import Bodegas from "./components/Bodegas"

const App = () => {
  useEffect(() => {
    // Establecer el token cuando se monta el componente App
    localStorage.setItem("token", "mipersonalToken123");
  }, []);

  return (
    <Router>
      <nav className="navbar">
        <Link to="/clientes">Clientes</Link>
        <Link to="/productos">Productos</Link>
        <Link to="/bodegas">Bodegas</Link>
      </nav>

      <div className="contenido">
        <Routes>
          <Route path="/clientes" element={<Clientes />} />
          <Route path="/productos" element={<Productos />} />
          <Route path="/bodegas" element={<Bodegas />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;
