import axios from 'axios';

// Aqui nós criamos uma instância do axios com o endereço base do seu C#
const api = axios.create({
  // SUBSTITUA a URL abaixo pela porta que o seu Swagger do C# usa
  baseURL: 'https://localhost:7255/api', 
});

export default api;