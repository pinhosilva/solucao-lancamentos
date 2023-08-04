# Controle de Lançamentos

Avaliação técnica. 

------------

## Principais Funcionalidades

- #### Lançamentos
    Composto por Criação de um lançamento, lançamento de débito e crédito.

- ### Fluxo

<p align="center" width="100%">
  <img src="https://github.com/waldyr/Sublime-Installer/blob/master/sublime_text.png?raw=true"/>
</p>

## Executando o Projeto

- Para executar o projeto, você precisará ter o [docker](https://app.dbdesigner.net/signup "docker") instalado. Um software de contêiner que fornece uma camada de abstração e automação para virtualização de sistemas operacionais windowns e linux. Nosso caso estamos utilizando o linux.
- Certifique-se também que a porta `1433` esteja liberada.

#### Abra o terminal, entre na raiz do projeto e execute o comando:

`docker-compose up --build`

após a finalização do build, abrirá o Swagger com a documentação dos endpoints.

## Tecnologias usadas no projeto

- .Net 5.0
- Swagger (Documentação iterativa para API REST)
- DDD
- EntityFramework
- Dapper
- UnitOfWork
- Repository
- Service
- EventSourcing
- AggregateRoot

### Banco de dados

- SQL

## Features implementadas

### Funcionalidades

- Criar Lançamento.
- Lançar Débitos.
- Lançar Créditos.
- Extrato de lançamentos.