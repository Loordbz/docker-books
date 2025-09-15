# Loja de Livros

Este projeto é uma aplicação simples de uma loja de livros composta por:

- **API Backend em C# (.NET Core)** para gerenciar os livros.
- **Frontend estático** servido via NGINX que consome a API.
- **Banco de dados MySQL** para persistência dos dados.
- Tudo containerizado via Docker e Docker Compose.

---

## Estrutura do projeto

- `/books-back` — Backend C# (.NET Core)
- `/public` — Frontend estático (HTML, CSS, JS, imagens)
- `/docker` — Arquivos de configuração do Docker e NGINX
- `docker-compose.yml` — Orquestração dos containers

---

## Tecnologias utilizadas

- .NET Core 9 (API)
- NGINX
- MySQL 8
- Docker / Docker Compose
- JavaScript (fetch API)

---

## Como executar o projeto

### Pré-requisitos

- Docker instalado
- Docker Compose instalado

### Passos para rodar

1. Rode docker-compose build
2. Rode docker-compose up