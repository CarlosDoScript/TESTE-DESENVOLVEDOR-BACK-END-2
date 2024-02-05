# Leanwork Recursos Humanos
[![My Skills](https://skillicons.dev/icons?i=cs&perline=3)](https://skillicons.dev)   [![My Skills](https://skillicons.dev/icons?i=dotnet&perline=3)](https://skillicons.dev)

## Descrições do Projeto
Projeto WEB foi desenvolvido aplicando as camadas DDD, como foi proposto na atividade 2 nele eu utilizei a api do github para consumir os endpoint de usuários e seus respectivos repositórios com as informações gerais do usuário.
No projeto API foi utilizado um padrão de projeto de software chamado Mediator utilizei o pacote MediatR, facilitando a comunicação entre diferentes partes do código com isso foi desenvolvido um mini sistema de rh para empresa com suas específicas atribuições para os candidatos conforme o enunciado.
Para todos os projetos foi utilizando métodos assíncronos

### Tecnologias Utilizadas
- **ASP NET CORE MVC**: Utilizado para o desenvolvimento de sites web.
- **ASP NET CORE API**: Utilizando para o desenvolvimento de apis.
- **SQL SERVER**: Banco de dados utilizando para guardar informações.
- **CSS**: Utilizado para os estilos da página web.
- **HTML**: Utilizando para a construção de páginas web.
- **JS**: Utilizado para manipular o DOM.
- **JQUERY**: Biblioteca de JavaScript que simplifica muitas tarefas comuns de manipulação do DOM e interações com o usuário

  ### Funcionalidades Principais da API
  Foram Desenvolvidos 7 endpoints
  ### Endpoints
- **Users**: foi implementando o login, com a implementaçção do JWT Bearer.
- **Candidate**: foi feito um CRUD.
- **Interview**: foi feito um CRUD e tambem um método para a finalização da triagem, e o download do relatorio ao final da triagem, pegando a pontuação de cada tecnologia.
- **JobOpening**: foi feito um CRUD, é onde o usuário do rh cria as vagas.
- **Technology**: foi feito um CRUD, é onde o usuário do rh cria as tecnologias e os pesos de cada uma que a empresa trabalha.
- **TechnologyJobOpening**: foi feito um CRUD, é onde o usuário do rh vincula a tecnologia para as vagas criadas.
- **TecnologyCandidate**: foi feito um CRUD, é onde o usuário do rh vincula a tecnologia para os candidatos durante a entrevista do candidato.
