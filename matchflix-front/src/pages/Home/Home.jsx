import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import api from '../services/api'; // Ajuste o caminho da sua API se necessário
import './Home.css';
import { FiUsers, FiFilm, FiHeart, FiLogOut, FiList } from 'react-icons/fi';

function Home() {
  const navigate = useNavigate();
  
  // Estados de Navegação e Dados
  const [abaAtiva, setAbaAtiva] = useState('filmes');
  const [filmes, setFilmes] = useState([]);

  // Estados do Modal de Criar Grupo
  const [modalGrupoAberto, setModalGrupoAberto] = useState(false);
  const [novoGrupo, setNovoGrupo] = useState({ nome: '', descricao: '' });

  // Busca os filmes assim que a tela carrega
  useEffect(() => {
    const buscarFilmes = async () => {
      try {
        const response = await api.get('/Filmes');
        setFilmes(response.data);
      } catch (error) {
        console.error("Erro ao buscar filmes:", error);
      }
    };
    buscarFilmes();
  }, []);

  // Função para enviar o novo grupo para a API
  const handleCriarGrupo = async (e) => {
    e.preventDefault();
    try {
      // Exemplo de chamada para sua API (descomente e ajuste quando o backend estiver pronto)
      // await api.post('/Grupos', novoGrupo); 
      
      alert(`Grupo "${novoGrupo.nome}" criado com sucesso!`);
      setModalGrupoAberto(false); // Fecha o modal
      setNovoGrupo({ nome: '', descricao: '' }); // Limpa o formulário
      
      // Aqui você poderá chamar uma função para recarregar a lista de grupos depois
    } catch (error) {
      console.error("Erro ao criar grupo:", error);
      alert('Falha ao criar o grupo.');
    }
  };

  const renderizarConteudo = () => {
    switch (abaAtiva) {
      case 'grupos':
        return (
          <div className="conteudo-secao fade-in">
            <header className="dashboard-header">
              <div>
                <h2>Meus Grupos</h2>
                <p>Gerencie seus grupos de sessão.</p>
              </div>
              <button className="btn-primario" onClick={() => setModalGrupoAberto(true)}>
                + Novo Grupo
              </button>
            </header>
            <div className="estado-vazio">
              <div className="icone-vazio glow-ciano"><FiUsers size={55} /></div>
              <h3>Nenhum grupo ainda</h3>
              <p>Crie seu primeiro grupo e convide os amigos!</p>
            </div>
          </div>
        );
      case 'sessoes':
        return (
          <div className="conteudo-secao fade-in">
            <header className="dashboard-header">
              <div>
                <h2>Sessões de Votação</h2>
                <p>Crie sessões e gerencie votações do grupo.</p>
              </div>
              <button className="btn-primario">+ Nova Sessão</button>
            </header>
            <div className="aviso-barra">
              Você precisa de um grupo para criar sessões. <span>Crie um grupo primeiro.</span>
            </div>
            <div className="estado-vazio">
              <div className="icone-vazio glow-ciano"><FiFilm size={55} /></div>
              <h3>Nenhuma sessão ainda</h3>
              <p>Crie uma sessão para o seu grupo começar a votar!</p>
            </div>
          </div>
        );
      case 'matches':
        return (
          <div className="conteudo-secao fade-in">
            <header className="dashboard-header">
              <div>
                <h2>Matches & Avaliações</h2>
                <p>Registre sua avaliação e acompanhe os Matches.</p>
              </div>
            </header>
            <div className="sub-secao">
              <h4>❤️ Matches Registrados</h4>
              <p className="texto-mutado">Nenhum Match registrado ainda.</p>
            </div>
            <div className="sub-secao">
              <h4>🎬 Minhas Avaliações</h4>
              <div className="estado-vazio">
                <div className="icone-vazio glow-coracao"><FiHeart size={55} /></div>
                <h3>Nenhuma avaliação ainda</h3>
                <p>Avalie filmes e veja os Matches acontecerem!</p>
              </div>
            </div>
          </div>
        );
      case 'filmes':
        return (
          <div className="conteudo-secao fade-in">
            <header className="dashboard-header">
              <div>
                <h2>Acervo de Filmes</h2>
                <p>Gerencie os filmes disponíveis no sistema.</p>
              </div>
              <button className="btn-primario" onClick={() => navigate('/cadastro-filme')}>
                + Cadastrar Filme
              </button>
            </header>
            
            {filmes.length === 0 ? (
              <div className="estado-vazio">
                <div className="icone-vazio glow-ciano"><FiList size={55} /></div>
                <h3>Nenhum filme no acervo</h3>
                <p>Clique no botão acima para cadastrar o seu primeiro filme.</p>
              </div>
            ) : (
              <div className="grade-filmes">
                {filmes.map((filme) => (
                  <div key={filme.id} className="card-filme">
                    <img 
                      src={filme.poster_url || "https://via.placeholder.com/300x450?text=Sem+Capa"} 
                      alt={`Capa do filme ${filme.titulo}`} 
                      className="capa-filme"
                    />
                    <div className="info-filme">
                      <h4>{filme.titulo}</h4>
                      <p>{filme.anoLancamento} • {filme.duracao} min</p>
                    </div>
                  </div>
                ))}
              </div>
            )}
          </div>
        );
      default:
        return null;
    }
  };

  return (
    <div className="dashboard-layout">
      {/* Sidebar Lateral */}
      <aside className="sidebar">
        <div className="sidebar-logo">
          <span className="logo-icone">⚡</span>
          <h1>Match<span>Flix</span></h1>
        </div>

        <nav className="sidebar-nav">
          <button className={abaAtiva === 'grupos' ? 'nav-item ativo' : 'nav-item'} onClick={() => setAbaAtiva('grupos')}>
            <FiUsers /> Grupos
          </button>
          <button className={abaAtiva === 'sessoes' ? 'nav-item ativo' : 'nav-item'} onClick={() => setAbaAtiva('sessoes')}>
            <FiFilm /> Sessões
          </button>
          <button className={abaAtiva === 'matches' ? 'nav-item ativo' : 'nav-item'} onClick={() => setAbaAtiva('matches')}>
            <FiHeart /> Matches
          </button>
          <button className={abaAtiva === 'filmes' ? 'nav-item ativo' : 'nav-item'} onClick={() => setAbaAtiva('filmes')}>
            <FiList /> Filmes
          </button>
        </nav>

        <div className="sidebar-footer">
          <div className="perfil-usuario">
            <div className="avatar">M</div>
            <div className="info-usuario">
              <span className="nome">Matheus A. Duarte</span>
              <span className="email">matheus@email.com</span>
            </div>
          </div>
          <button className="btn-sair" onClick={() => navigate('/')}>
            <FiLogOut /> Sair
          </button>
        </div>
      </aside>

      {/* Área Central Principal */}
      <main className="dashboard-main">
        {renderizarConteudo()}
      </main>

      {/* =======================================
          MODAL DE CRIAR GRUPO
          ======================================= */}
      {modalGrupoAberto && (
        <div className="modal-overlay">
          <div className="modal-content">
            <h3>Criar Novo Grupo</h3>
            <p>Dê um nome para a sua galera se reunir.</p>
            
            <form onSubmit={handleCriarGrupo} className="form-modal">
              <input 
                type="text" 
                placeholder="Nome do Grupo (ex: Cinema de Sexta)" 
                value={novoGrupo.nome}
                onChange={(e) => setNovoGrupo({...novoGrupo, nome: e.target.value})}
                required 
              />
              <textarea 
                placeholder="Descrição (opcional)" 
                value={novoGrupo.descricao}
                onChange={(e) => setNovoGrupo({...novoGrupo, descricao: e.target.value})}
                rows="3"
              />
              
              <div className="modal-actions">
                <button 
                  type="button" 
                  className="btn-secundario" 
                  onClick={() => setModalGrupoAberto(false)}
                >
                  Cancelar
                </button>
                <button type="submit" className="btn-primario">
                  Criar Grupo
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
}

export default Home;