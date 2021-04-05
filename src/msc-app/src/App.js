import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import DropdownButton from 'react-bootstrap/DropdownButton';
import Dropdown from 'react-bootstrap/Dropdown'


function App() {
  const [value, setValue] = useState('');
  const [input, setInput] = useState('')
  const [data, setData] = useState(0)

  const handleSelect=(e)=>{
    console.log(e);
    setValue(e)
  }

  const onClick = () => {
    let url = 'http://localhost:57840/api/ConvertCurrency?currency={value}&value={input}'

    url = url.replace(
      '{value}',
      encodeURIComponent('' + value)
    );

    url = url.replace(
      '{input}',
      encodeURIComponent('' + input)
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
      title="Dropdown right"
      id="dropdown-menu-align-right"
      onSelect={handleSelect}
        >
              <Dropdown.Item eventKey="GBP">GBP</Dropdown.Item>
              <Dropdown.Item eventKey="EUR">EUR</Dropdown.Item>
      </DropdownButton>

      <div>
      <label>Please specify:</label>
      <input value={input} onInput={e => setInput(e.target.value)}/>
      </div>
      <h4>You selected {value}</h4>
      <h4>You selected {input}</h4>

      <div>
      <button onClick={onClick}>Get data</button>
      <div>{data}</div>
    </div>
    </div>
  );
}

export default App;