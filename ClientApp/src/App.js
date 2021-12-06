import React, { Component } from 'react';

export class App extends Component {
  static displayName = App.name;

  constructor(props) {
    super(props);
    this.state = { products: [], loading: true, err: {} };
  }

  componentDidMount() {
    setInterval(() => {
      this.fetchProducts();
    }, 5000);
  }

  async fetchProducts() {
    //const response = await fetch('api/products');
    // const data = await response.json();
    // this.setState({ products: data, loading: false });

    fetch('api/products')
    .then(response => response.json())
    .then(data => this.setState({ products: data, loading: false }))
    .catch(error => this.setState({ products: [], loading: false, err: error }))
  }

  render() {
    let bodyOk = (<>
      <h2>Beers</h2>
      <table>
        <thead>
          <tr>
            <th align="left">Product</th>
            <th align="left">Temperature</th>
            <th align="left">Status</th>
          </tr>
        </thead>
        <tbody>
          {this.state.products.map((product) => (
            <tr key={product.id}>
              <td width={150}>{product.name}</td>
              <td width={150}>{product.temperature}</td>
              <td width={150}>{product.temperatureStatus}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>);
    let bodyErr = <p><em>{this.state.err.code} - {this.state.err.message}</em></p>
    let contents = this.state.loading ? <p><em>Loading...</em></p> : this.state.err == {} ? bodyErr : bodyOk;
    
    return (
      <>
        <header>
          <h1>SensorTech</h1>
        </header>
        <main>
          {contents}
        </main>
      </>
    );
  }
}
