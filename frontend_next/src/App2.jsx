import { useEffect, useState } from "react";
import Products from "./components/Products"

function App2() {
  const API_URL = import.meta.env.VITE_APP_API_URL
  const [prueba, setDataP] = useState(null);
  const [dataProducts, setDataProductos] = useState('');
  const [error, setError] = useState('');

  const [dataProduct, setDataProducto] = useState('');
  const [idProducto, setIdProducto] = useState('');

  useEffect(() => {
    fetch(`${API_URL}/weatherforecast`) // Nginx redirige al backend cuando esta configurado el proxy en el nginx.conf /api
      .then(res => res.json())
      .then(setDataP)
      .catch(setError);
    
  }, []);

  //Productos
  const buscarProductos = async () => {
    try {
      fetch(`${API_URL}/api/products/GetProducts`) // Nginx redirige al backend
        .then(res => res.json())
        .then(setDataProductos)
        .catch(setError);

    } catch (err) {
      console.log(err.toString());
    }
  }

  const limpiarProductos = () => {
    setDataProductos('');
  }

  //Producto
  const buscarProducto = async () => {
    try {
      fetch(`${API_URL}/api/products/GetProductById/${idProducto}`) // Nginx redirige al backend
        .then(res => res.json())
        .then(setDataProducto)
        .catch(setError);

    } catch (err) {
      console.log(err.toString());
    }
  }

  const limpiarProducto = () => {
    setDataProducto('');
    setIdProducto('');
  }



  return (
    <div style={{ padding: "2rem" }}>
      <h1>🚀 Frontend React con Nginx - JdParedesC</h1>
      <div>HOLA </div>
      <pre>{JSON.stringify(prueba, `No hay conexion al backend`, 2)}</pre>
      <hr></hr>
      <button onClick={buscarProductos}>Search</button>
      <button onClick={limpiarProductos}>Clear</button>
      <pre>{JSON.stringify(dataProducts, "No hay conexion a la base de datos", 2)}</pre>
      <hr />
      <a href="http://localhost:5000/weatherforecast">{API_URL}/weatherforecast</a>
      <hr />
      <div>
        <label>
          Id de producto{" "}
          <input
            type="text"
            value={idProducto}
            onChange={(e) => setIdProducto(e.target.value)}
            placeholder="Ej: 1"
          />
        </label>
        <button onClick={buscarProducto}>Search</button>
        <button onClick={limpiarProducto}>Clear</button>
        <pre>{JSON.stringify(dataProduct, "No hay conexion a la base de datos", 2)}</pre>
      </div>
      <hr />
      <Products productos={JSON.stringify(dataProduct)}></Products>
      <hr />
      <p>Errores:</p>
      <pre>{JSON.stringify(error, "No hay conexion a la base de datos", 2)}</pre>
    </div>
  );
}

export default App2;
