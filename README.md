# MatchFlix 🍿⚡

> **A solução para a fadiga de decisão coletiva no entretenimento.**

O MatchFlix é uma aplicação Full-Stack que resolve um problema real: grupos de amigos que perdem horas tentando decidir qual filme assistir. A dinâmica é simples — cada pessoa vota individualmente nos filmes de uma sessão, e quando **todos do grupo dão like no mesmo filme, dá Match!**

Projeto desenvolvido como Trabalho Prático da disciplina de **Banco de Dados — PUC**.

---

## 🧱 Arquitetura do Sistema

```
┌─────────────────┐       HTTP/REST      ┌─────────────────┐       EF Core       ┌──────────┐
│  Front-end      │ ──────────────────► │   API (Garçom)  │ ──────────────────► │  MySQL   │
│  React + Vite   │ ◄────────────────── │  C# .NET 9      │ ◄────────────────── │  (Banco) │
└─────────────────┘      JSON           └─────────────────┘       LINQ           └──────────┘
   localhost:5173                           localhost:7255
```

---

## 🚀 Tecnologias Utilizadas

### Back-end
| Tecnologia | Função |
|---|---|
| **.NET 9** | Runtime da aplicação |
| **ASP.NET Core Web API** | Framework para a API REST |
| **Entity Framework Core 9** | ORM — Mapeamento Code First |
| **Data Annotations** | Definição das constraints do banco via C# |
| **Pomelo MySQL** | Driver de conexão com o MySQL |
| **Swagger / OpenAPI** | Documentação e teste das rotas |

### Front-end
| Tecnologia | Função |
|---|---|
| **React 19** | Biblioteca de interface (SPA) |
| **Vite** | Bundler e servidor de desenvolvimento |
| **React Router DOM** | Navegação entre páginas |
| **Axios** | Chamadas HTTP para a API |
| **React Icons** | Biblioteca de ícones |

---

## 📂 Estrutura do Projeto

```
MatchFlix/
├── MatchFlix/                  # Back-end (.NET)
│   ├── Controllers/            # Endpoints da API (regras de negócio)
│   │   ├── UsuariosController  # Cadastro e login
│   │   ├── FilmesController    # Catálogo de filmes
│   │   ├── GenerosController   # Categorias
│   │   ├── GruposController    # Criação de grupos e membros
│   │   └── SessoesController   # Votação e cálculo de Matches ⭐
│   ├── Models/                 # Entidades mapeadas com Data Annotations
│   ├── DTOs/                   # Objetos de transferência de dados
│   ├── Migrations/             # Histórico de versões do banco
│   ├── AppDbContext.cs         # Contexto do Entity Framework
│   └── Program.cs              # Configuração e inicialização da API
│
└── matchflix-front/            # Front-end (React)
    └── src/
        ├── pages/
        │   ├── Login/          # Tela de autenticação
        │   ├── cadastro/       # Cadastro de usuário e filmes
        │   ├── Home/           # Dashboard principal
        │   └── services/
        │       └── api.js      # Instância centralizada do Axios
        ├── App.jsx             # Roteamento principal
        └── main.jsx            # Entry point
```

---

## 🗄️ Modelagem do Banco de Dados

O banco foi estruturado com **10 tabelas relacionais** usando a abordagem **Code First com Data Annotations**:

| Tabela | Descrição |
|---|---|
| `Usuario` | Dados dos usuários cadastrados |
| `FILME` | Catálogo de filmes disponíveis |
| `Genero` | Categorias (Ação, Comédia, Terror...) |
| `Filme_Genero` | Relação N:N entre Filmes e Gêneros |
| `Grupo_Sessao` | Grupos criados pelos usuários |
| `Membro_Grupo` | Vínculo entre Usuários e Grupos |
| `Sessao` | Sessões de votação abertas em um grupo |
| `Sessao_Filme` | Filmes disponíveis para votar em uma sessão |
| `Avaliacao` | Votos individuais (like/dislike) de cada usuário |
| `Match` | ⭐ Registra quando todos votaram no mesmo filme |

### A Lógica do Match
O cálculo é feito automaticamente pela API a cada voto:
```
total de "likes" no filme == total de membros do grupo → DEU MATCH! 🎉
```

---

## 🛠️ Como Executar Localmente

### Pré-requisitos
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [MySQL](https://dev.mysql.com/downloads/installer/) rodando localmente
- [Node.js](https://nodejs.org/) (versão 18+)

### 1. Clonar o repositório
```bash
git clone https://github.com/SEU_USUARIO/MatchFlix.git
```

### 2. Criar o banco de dados
No MySQL, crie o banco antes de subir a API:
```sql
CREATE DATABASE MatchFlix;
```

### 3. Configurar a conexão
Abra `MatchFlix/appsettings.json` e ajuste com suas credenciais:
```json
"ConnectionStrings": {
  "ConexaoMysql": "server=localhost;database=MatchFlix;user=root;password=SUA_SENHA"
}
```

### 4. Subir o Back-end
```bash
cd MatchFlix/MatchFlix
dotnet run
```
> ✅ As migrations são aplicadas **automaticamente** na primeira execução. Não é necessário rodar `dotnet ef database update`.

A API estará disponível em: `https://localhost:7255`  
Documentação Swagger: `https://localhost:7255/swagger`

### 5. Subir o Front-end
```bash
cd matchflix-front
npm install   # apenas na primeira vez
npm run dev
```

A interface estará disponível em: `http://localhost:5173`

---

## 🔌 Principais Endpoints da API

| Método | Rota | Descrição |
|---|---|---|
| `POST` | `/api/Usuarios/cadastrar` | Cadastra novo usuário |
| `POST` | `/api/Usuarios/login` | Autentica e retorna dados do usuário |
| `GET` | `/api/Filmes` | Lista todos os filmes do catálogo |
| `POST` | `/api/Filmes` | Cadastra um novo filme |
| `POST` | `/api/Grupos` | Cria um grupo e adiciona o criador como membro |
| `POST` | `/api/Grupos/adicionar-membro` | Adiciona um usuário a um grupo existente |
| `POST` | `/api/Sessoes` | Abre uma nova sessão de votação |
| `POST` | `/api/Sessoes/adicionar-filme` | Adiciona um filme à sessão |
| `POST` | `/api/Sessoes/votar` | Registra um voto e verifica se deu Match ⭐ |
| `GET` | `/api/Sessoes/{id}/matches` | Lista todos os Matches de uma sessão |

---

## 👥 Integrantes

| Nome | Contribuição Principal |
|---|---|
| Eduardo Henrick | 💡 Idealizador do projeto · Modelagem do banco (Data Annotations) · Controllers |
| Matheus Aurélio | Front-end (React) · Design da interface |
| Caique de Lima | Desenvolvimento |
| Gustavo Ferreira | Desenvolvimento |
| Fabio Henrique | Desenvolvimento |
| Pablo Henrique | Desenvolvimento |

---

*Trabalho Prático — Disciplina: Banco de Dados — PUC*
