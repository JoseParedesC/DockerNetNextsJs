import { useState } from "react";

const Weather = ({}) => {
    const API_URL = import.meta.env.VITE_APP_API_URL
    const [data, setData] = useState(null);

    //Weather
    const buscarDataClima = async () => {
        try {
            fetch(`${API_URL}/weatherforecast`)
            .then(res => res.json())
            .then(setData);

        } catch (err) {
            console.log(err.toString());
        }
    }

    const limpiarDataClima = () => {
        setData('');
    }

    return (
        <div>
            <button onClick={buscarDataClima}>Search</button>
            <button onClick={limpiarDataClima}>Clear</button>
            <div>
                <pre>{JSON.stringify(data, null, 2)}</pre>
            </div>
        </div>
    );
}

export default Weather;