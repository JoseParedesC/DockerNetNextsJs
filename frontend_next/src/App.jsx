import { useEffect, useState } from "react";

function App() {
  const API_URL = import.meta.env.VITE_APP_API_URL
  const [prueba, setDataP] = useState(null);
  const [data, setData] = useState(null);
  const [ventas, setVentas] = useState(null);
  const [error, setError] = useState(null);

  //Facturas
  const [codigoFactura, setCodigoFactura] = useState(null);
  const [dataFactura, setDataFactura] = useState(null);

  //Facturas Items
  const [codigoFacturaI, setCodigoFacturaI] = useState(null);
  const [dataFacturaI, setDataFacturaI] = useState(null);

  //Usuarios
  // const [idUsuario, setIdiUsuario] = useState(null);
  const [dataUsusario, setDataUsuario] = useState(null);

  useEffect(() => {
    fetch(`${API_URL}/api/prueba`) // Nginx redirige al backend cuando esta configurado el proxy en el nginx.conf /api
      .then(res => res.json())
      .then(setDataP)
      .catch(setError);

    // fetch(`${API_URL}/api/products`) // Nginx redirige al backend
    //   .then(res => res.json())
    //   .then(setVentas)
    //   .catch(setError);
    
    fetch(`${API_URL}/api/ventas/ventas_details`) // Nginx redirige al backend
      .then(res => res.json())
      .then(setData)
      .catch(setError);
  }, []);

  //Facturas
  const buscarFactura = async () => {
    if(!codigoFactura.trim())
      alert("Ingrese un codigo de Factura valido");

    try {
      fetch(`${API_URL}/api/ventas/ventas_details/${codigoFactura}`) // Nginx redirige al backend
        .then(res => res.json())
        .then(setDataFactura)
        .catch(setError);

    } catch (err) {
      console.log(err.toString());
    }
  }

  const limpiarFactura = () => {
    setDataFactura('');
    setCodigoFactura('');
  }



  //Facturas Items
  const buscarFacturaItems = async () => {
    if(!codigoFacturaI.trim())
      alert("Ingrese un codigo de Factura valido");

    try {
      fetch(`${API_URL}/api/ventas/ventas_items/${codigoFacturaI}`) // Nginx redirige al backend
        .then(res => res.json())
        .then(setDataFacturaI)
        .catch(setError);

    } catch (err) {
      console.log(err.toString());
    }
  }

  const limpiarFacturaItems = () => {
    setDataFacturaI('');
    setCodigoFacturaI('');
  }



  //Usuarios
  const buscarUsuarios = async () => {
    try {
      fetch(`${API_URL}/api/users/find`)
        .then(res => res.json())
        .then(setDataUsuario)
        .catch(setError);

    } catch (err) {
      console.log(err.toString());
    }
  }

  const limpiarUsuarios = () => {
    setDataUsuario('');
  }

  return (
    <div style={{ padding: "2rem" }}>
      <h1>🚀 Frontend React con Nginx - JdParedesC</h1>
      <div>HOLA </div>
      <pre>{JSON.stringify(prueba, `No hay conexion al backend`, 2)}</pre>
      <hr />
      <a href="https://backend-service-959958084950.us-central1.run.app/api/prueba">{API_URL}/api/prueba</a>
      <hr></hr>
      {/* <pre>{JSON.stringify(data, "No hay conexion a la base de datos", 2)}</pre> */}
      <hr></hr>
      <div>
        <label>
          Código de factura - Pool:{" "}
          <input
            type="text"
            value={codigoFactura}
            onChange={(e) => setCodigoFactura(e.target.value)}
            placeholder="Ej: FAC-001"
          />
        </label>
        <button onClick={buscarFactura}>Search</button>
        <button onClick={limpiarFactura}>Clear</button>
        <pre>{JSON.stringify(dataFactura, "No hay conexion a la base de datos", 2)}</pre>
      </div>
      <hr />
      <div>
        <label>
          Código de factura - Sequelize:{" "}
          <input
            type="text"
            value={codigoFacturaI}
            onChange={(e) => setCodigoFacturaI(e.target.value)}
            placeholder="Ej: FAC-001"
          />
        </label>
        <button onClick={buscarFacturaItems}>Search</button>
        <button onClick={limpiarFacturaItems}>Clear</button>
        <pre>{JSON.stringify(dataFacturaI, "No hay conexion a la base de datos", 2)}</pre>
      </div>
      <hr />
      <div>
        <label>
          Usuarios - Sequelize:{" "}
          {/* <input
            type="text"
            value={idUsuario}
            onChange={(e) => setIdiUsuario(e.target.value)}
            placeholder="Ej: FAC-001"
          /> */}
        </label>
        <button onClick={buscarUsuarios}>Search</button>
        <button onClick={limpiarUsuarios}>Clear</button>
        <pre>{JSON.stringify(dataUsusario, "No hay conexion a la base de datos", 2)}</pre>
      </div>
      {/* <pre>{JSON.stringify(ventas, "No hay conexion a la base de datos", 2)}</pre> */}
      <p>Errores:</p>
      <pre>{JSON.stringify(error, "No hay conexion a la base de datos", 2)}</pre>
    </div>
  );
}

export default App;
