import React, { useEffect, useState } from 'react';
import api from '../../../src/pages/services/api.js';
import './Home.css';

function Home() {
  const [filmes, setFilmes] = useState([]);

  useEffect(() => {
    const buscarFilmes = async () => {
      try {
        const resposta = await api.get('/Filmes'); 
        console.log("Dados recebidos:", resposta.data);
        setFilmes(resposta.data);
      } catch (error) {
        console.error("Erro na busca dos filmes:", error.response || error.message);
      }
    };

    buscarFilmes();
  }, []);

  return (
    <div className="home-container">
      <header>
        <h1>MatchFlix</h1>
        <button onClick={() => { localStorage.clear(); window.location.href = '/'; }}>
          Sair
        </button>
      </header>

      <main>
        <h2>Filmes disponíveis</h2>
        <div className="lista-filmes">
          {filmes.length > 0 ? (
            filmes.map((filme) => (
              <div key={filme.id_Filme} className="card-filme">
                {/* Imagem do banner */}
                <img 
                  src={filme.poster_url} 
                  alt={filme.titulo} 
                  className="banner-filme" 
                />
                
                <div className="info-filme">
                  <h3>{filme.titulo}</h3>
                  <p className="sinopse">{filme.sinopse}</p>
                  <div className="detalhes">
                    <span>📅 {filme.anoLancamento}</span>
                    <span>⏳ {filme.duracao} min</span>
                  </div>
                </div>
              </div>
            ))
          ) : (
            <p>Nenhum filme encontrado.</p>
          )}
        </div>
      </main>
    </div>
  );
}

export default Home;