import React, { useState } from 'react';
import api from '/src/pages/services/api.js'; 
import './CadastroFilme.css';

function CadastroFilme() {
  const [filme, setFilme] = useState({
    titulo: '',
    sinopse: '',
    anoLancamento: '',
    duracao: '',
    poster_url: ''
  });

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await api.post('/Filmes', filme);
      alert('Filme cadastrado com sucesso!');
      window.location.href = '/home'; // Redireciona para a home após salvar
    } catch (error) {
      console.error("Erro ao cadastrar:", error);
      alert('Falha ao cadastrar o filme. Verifique o console.');
    }
  };

return (
    <div className="cadastro-container"> {/* CSS vai controlar o tamanho e margem */}
      <h2>Cadastrar Novo Filme</h2>
      <form onSubmit={handleSubmit} className="form-cadastro"> {/* Usando a classe do seu CSS */}
        <input type="text" placeholder="Título" onChange={(e) => setFilme({...filme, titulo: e.target.value})} required />
        <input type="text" placeholder="Sinopse" onChange={(e) => setFilme({...filme, sinopse: e.target.value})} />
        <input type="number" placeholder="Ano de Lançamento" onChange={(e) => setFilme({...filme, anoLancamento: parseInt(e.target.value)})} />
        <input type="number" placeholder="Duração (min)" onChange={(e) => setFilme({...filme, duracao: parseInt(e.target.value)})} />
        <input type="text" placeholder="URL da Capa" onChange={(e) => setFilme({...filme, poster_url: e.target.value})} />
        <button type="submit">Salvar Filme</button>
      </form>
    </div>
  );
}

export default CadastroFilme;