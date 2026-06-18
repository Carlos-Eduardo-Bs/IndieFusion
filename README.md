# Sistema Corporativo Integrado (API, Desktop & Web)

## 💻 Sobre o Projeto
Este é um sistema de grande porte desenvolvido para simular um ambiente corporativo robusto e integrado. A solução foi estruturada de forma modular, dividida em três ecossistemas principais que comunicam entre si para garantir a consistência dos dados e a separação de responsabilidades.

O objetivo principal do projeto foi aplicar padrões de arquitetura de software, criação/consumo de serviços e boas práticas de programação utilizando a plataforma .NET.

---

## 🏗️ Arquitetura do Sistema

O projeto está dividido nos seguintes módulos:

1. **Web API (Backend):** 
   * Responsável por toda a regra de negócio do sistema.
   * Disponibilização de rotas e endpoints através de uma API RESTful.
   * Tratamento centralizado de exceções e persistência de dados.

2. **Aplicação Web (Frontend/Client):**
   * Interface web desenvolvida utilizando o padrão **MVC (Model-View-Controller)**.
   * Consome os dados diretamente da Web API para exibição dinâmica de relatórios, cadastros e gestão de utilizadores.

3. **Aplicação Desktop (Client):**
   * Módulo local/administrativo desenvolvido em C# para operações internas pesadas e gestão do sistema, conectando-se diretamente à API central.

---

## 🛠️ Tecnologias e Ferramentas Utilizadas

* **Linguagem Principal:** C#
* **Framework Backend:** .NET Core / ASP.NET Web API
* **Padrão Arquitetural:** MVC (Model-View-Controller) & Arquitetura em Camadas
* **Persistência de Dados:** Entity Framework Core / LINQ / SQL Server (Noções de Banco Relacional)
* **Boas Práticas:** Princípios SOLID, Clean Code e Injeção de Dependência

---

## 🎯 Conceitos Práticos Aplicados

* Criação e consumo de endpoints HTTP (GET, POST, PUT, DELETE).
* Separação rigorosa de responsabilidades entre a lógica de apresentação e as regras de negócio.
* Modelagem de dados relacionais e manipulação de entidades complexas.
* Desenvolvimento voltado para a manutenibilidade, sustentação e facilidade de implementação de futuras melhorias.
