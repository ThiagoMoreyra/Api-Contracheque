# Api-Contracheque

# Api-Contracheque -  Gerenciamento da contabilidade e pagamento de seus funcionários.

<!--ts-->
   * [Sobre](#Sobre)
   * [Status do Projeto](#Status)
   * [Instalação](#instalacao)
   * [Como usar](#como-usar)
      * [Tecnologias](#Tecnologias)
      * [Scripts](#Scripts)      
   * [Execução no Docker](#Docker)      
<!--te-->

<h4>* Sobre: </h4>

<p> - Na empresa existe um setor responsável pela contabilidade e pagamento de seus funcionários, entretanto, a parte contábil é realizada por uma consultoria externa. Gerir essas informações é algo bem importante e, dado que há uma confidencialidade no tráfego desses dados e também há uma possibilidade de economizar tirando essa consultoria do jogo, você foi escalado para criar uma aplicação responsável por criar o extrato da folha salarial dos funcionários. Esse extrato deve expôr o salário líquido do funcionário e todos os seus descontos discriminados.</p>

<h4>* Status do projeto: </h4>

<p> - Finalizado.</p>

<h4>* Instalação: </h4>

<p> - Instalar a IDE Visual Studio 2019 <br> Segue o Link: https://visualstudio.microsoft.com/pt-br/vs/community/</p>

<h4>* Como usar: </h4>

<p> - Abra o prompt de comando e vá até a pasta do projeto e digite os seguintes comandos:</p>

<b> 1 - dotnet restore </b><br>
<b> 2 - Vá até a pasta <i>src/Stone.Api.Contracheque.App<i> e digite dotnet run </b><br>
  
<h4>* Tecnologias: </h4>
<p>
  1 - .NET Core 3.1 <br>
  2 - Sql Server <br>
  3 - Entity FrameWork 3.1.14<br>   
  4 - XUnit
  5 - Docker
</p>

<h4>* Scripts</h4>

<p> - Na pasta: <i>Stone.Api.Contrecheque\src\Stone.Api.Contracheque.Repository\Script</i> está o script de criação de tabelas</p>

<h4>* Execução no Docker: </h4>

<p> - Executar o comando <i>docker pull thiagomoreira/stoneapicontrachequeapp:latest</i> para baixar a imagem no Docker Hub</p>
<p> - Executar o comando <i>docker run -t -i thiagomoreira/stoneapicontrachequeapp:latest</i> para executar a imagem baixada do Docker Hub</p>
