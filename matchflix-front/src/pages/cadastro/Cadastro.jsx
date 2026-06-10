import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import './Cadastro.css'; 

function Cadastro() {
  const [nome, setNome] = useState('');
  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');
  const [confirmarSenha, setConfirmarSenha] = useState(''); // Estado para o campo extra da foto

  const handleCadastro = (e) => {
    e.preventDefault();
    if (senha !== confirmarSenha) {
      alert("As senhas não coincidem!");
      return;
    }
    // Sua lógica de enviar para a API C# depois!
    console.log({ nome, email, senha });
  };

  return (
    <div className="cadastro-page-container">
      
      {/* PAINEL ESQUERDO: Mensagem de Impacto e Recursos */}
      <div className="cadastro-left-panel">
        <span className="icone-claquete">🎬</span>
        <h2>Pare de perder tempo escolhendo filmes.</h2>
        <p>Cadastre-se, monte seu grupo e comece a dar Matches agora mesmo.</p>
        
        <div className="cadastro-beneficios">
          <span className="beneficio-item">✓ Cadastro gratuito</span>
          <span className="beneficio-item">✓ Grupos ilimitados</span>
          <span className="beneficio-item">✓ Match instantâneo</span>
        </div>
      </div>

      {/* PAINEL DIREITO: Formulário Fixo Lateral */}
      <div className="cadastro-right-panel">
        
        {/* Identidade MatchFlix */}
        <div className="logo-matchflix">
          <span className="logo-icone">⚡</span>
          <h1>Match<span>Flix</span></h1>
        </div>

        {/* Cabeçalho do Formulário */}
        <div className="form-header-text">
          <h3>Criar sua conta</h3>
          <p>É rápido e gratuito.</p>
        </div>

        {/* Formulário com os Inputs conectados aos seus estados */}
        <form onSubmit={handleCadastro} className="form-cadastro-usuario">
          
          <div className="input-group">
            <label>Nome completo</label>
            <input 
              type="text" 
              placeholder="Seu nome" 
              value={nome}
              onChange={(e) => setNome(e.target.value)}
              required 
            />
          </div>

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
              placeholder="Mín. 6 caracteres" 
              value={senha}
              onChange={(e) => setSenha(e.target.value)}
              required 
            />
          </div>

          <div className="input-group">
            <label>Confirmar senha</label>
            <input 
              type="password" 
              placeholder="Repita a senha" 
              value={confirmarSenha}
              onChange={(e) => setConfirmarSenha(e.target.value)}
              required 
            />
          </div>

          <button type="submit">
            <span style={{ fontSize: '1.1rem' }}></span> Criar Conta
          </button>
        </form>

        {/* Link para voltar ao Login */}
        <div className="link-login">
          Já tem conta? <Link to="/">Entrar</Link>
        </div>

      </div>
    </div>
  );
}

export default Cadastro;