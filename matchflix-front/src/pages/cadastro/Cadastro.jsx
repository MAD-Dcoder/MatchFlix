import React from 'react';
import { useNavigate } from 'react-router-dom';
import './Cadastro.css';

function Cadastro() {
  const navigate = useNavigate();

  return (
    <div className="cadastro-container">
      
      {/* LADO ESQUERDO: Banner Decorativo */}
      <div className="cadastro-banner-section">
        <div className="banner-content">
          <span className="star-icon">✨</span>
          <h2>Faça parte do grupo.</h2>
          <p>Crie sua conta agora e comece a dar Match nos melhores filmes com a galera.</p>
        </div>
      </div>

      {/* LADO DIREITO: Formulário */}
      <div className="cadastro-form-section">
        <div className="logo">
          <span className="logo-icon">⚡</span> MatchFlix
        </div>

        <div className="form-content">
          <h2>Criar Conta</h2>
          <p className="subtitle">Preencha os dados abaixo para se cadastrar grátis.</p>

          <form>
            <div className="input-group">
              <label>Nome Completo</label>
              <input type="text" placeholder="Seu nome" />
            </div>

            <div className="input-group">
              <label>E-mail</label>
              <input type="email" placeholder="seu@email.com" />
            </div>

            <div className="input-group">
              <label>Senha</label>
              <input type="password" placeholder="Crie uma senha segura" />
            </div>

            <button type="button" className="btn-cadastrar">
              ➔ Cadastrar
            </button>
          </form>

          <p className="login-link">
            Já tem conta? <span onClick={() => navigate('/login')}>Faça login</span>
          </p>
        </div>
      </div>

    </div>
  );
}

export default Cadastro;