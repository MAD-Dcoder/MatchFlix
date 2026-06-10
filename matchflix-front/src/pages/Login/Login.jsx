import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import api from '../../../src/pages/services/api.js';
import './Login.css';

function Login() {
  const navigate = useNavigate();
  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');

  const handleLogin = async (e) => {
    e.preventDefault(); // Impede o recarregamento da página
    
    try {
      // Faz a chamada para a API
      const resposta = await api.post('/Usuarios/login', { email, senha });
      
      // Se deu certo, ele pula direto para a Home
      console.log("Login efetuado com sucesso:", resposta.data);
      navigate('/home'); 
      
    } catch (error) {
      // Se deu erro (senha errada, servidor offline), ele avisa aqui
      console.error("Erro no login:", error);
      alert('Erro ao fazer login. Verifique suas credenciais.');
    }
  };

  return (
    <div className="login-container">
      {/* LADO ESQUERDO: Formulário */}
      <div className="login-form-section">
        <div className="sidebar-logo">
          <span className="logo-icone">⚡</span>
            <h1>Match<span>Flix</span></h1>
        </div>

        <div className="form-content">
          <h2>Bem-vindo de volta</h2>
          <p className="subtitle">Entre na sua conta para continuar.</p>

          <form onSubmit={handleLogin}>
            <div className="input-group">
              <label>E-mail</label>
              <input 
                type="email" 
                placeholder="seu@email.com" 
                value={email} 
                onChange={(e) => setEmail(e.target.value)} 
                required
              />
            </div>

            <div className="input-group">
              <label>Senha</label>
              <input 
                type="password" 
                placeholder="Sua senha" 
                value={senha} 
                onChange={(e) => setSenha(e.target.value)} 
                required
              />
            </div>

            <button type="submit" className="btn-entrar">
              ➔ Entrar
            </button>
          </form>

          <p className="register-link">
            Não tem conta? <span onClick={() => navigate('/cadastro')}>Cadastre-se grátis</span>
          </p>
        </div>
      </div>

      {/* LADO DIREITO: Banner */}
      <div className="login-banner-section">
        <div className="banner-content">
          <span className="heart-icon">❤️</span>
          <h2>Seu próximo Match<br/>está te esperando.</h2>
          <p>Entre na sua conta e descubra qual filme o grupo vai assistir hoje.</p>
        </div>
      </div>
    </div>
  );
}

export default Login;