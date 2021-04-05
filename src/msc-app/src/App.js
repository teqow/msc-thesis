import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import DropdownButton from 'react-bootstrap/DropdownButton';
import Dropdown from 'react-bootstrap/Dropdown'
import apiConfig from './api.config.json';

function App() {
  const [currency, setValue] = useState('');
  const [value, setInput] = useState('')
  const [data, setData] = useState(0)

  const handleSelect=(e)=>{
    console.log(e);
    setValue(e)
  }

  const onClick = () => {
    let url = apiConfig.ApiUrl + "ConvertCurrency?currency={currency}&value={value}";

    url = url.replace(
      '{currency}',
      encodeURIComponent('' + currency)
    );

    url = url.replace(
      '{value}',
      encodeURIComponent('' + value)
    );

    fetch(url)
    .then(res => res.json())
    .then(
      (result) => {
        setData(result);
      }
    )
    }

  return (
    <div className="App container">
      
      <DropdownButton
      alignRight
      title="Select Currency"
      id="dropdown-menu-align-right"
      onSelect={handleSelect}
        >
              <Dropdown.Item eventKey="GBP">GBP</Dropdown.Item>
              <Dropdown.Item eventKey="EUR">EUR</Dropdown.Item>
      </DropdownButton>

      <div>
      <label>Value</label>
      <input value={value} onInput={e => setInput(e.target.value)}/>
      </div>
      <h4>You selected {currency}</h4>
      <h4>You selected {value}</h4>

      <div>
      <button onClick={onClick}>Get data</button>
      <div>{data}</div>
    </div>
    </div>
  );
}

export default App;