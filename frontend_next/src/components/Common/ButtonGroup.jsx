import { useState } from 'react';
import { sumarTs } from './Ts/ButtonGroupScript';
import { sumarJs } from './Js/ButtonGroupScript'

const ButtonGroup = ({ dataPages }) => {
    const [sumaJs, setSumaJs] = useState('');
    const [sumaTs, setSumaTs] = useState('');

    const mostarPagina = (item) => {
        alert(`Pagina para mostrar: ${item.PageCmp}`)
    }

    function sumar(a, b){
        try
        {
            setSumaJs(sumarJs(a, b));
        }catch(err){
            console.log(err);
        }

        try
        {
            setSumaTs(sumarTs(a, b));
        }catch(err){
            console.log(err);
        }
    }

    return (
        <div>
            {
                dataPages.map((item, index) => {
                    return(
                        <button onClick={() => mostarPagina(item)}>{item.PageName}</button>
                    );
                })
            }
            {/* <button onClick="">Default</button>
            <button onClick="">Productos</button> */}
            <button class="button" onClick={() => sumar(10, "20")}>Sumar</button>
            <button className="button" onClick={() => setSumaTs(10, "20")}>Sumar</button>
            <ul>
                <li>Suma Js: {sumaJs}</li>
                <li>Suma Ts: {sumaTs}</li>
            </ul>
        </div>
    );
}

export default ButtonGroup;