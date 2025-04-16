# .NET 8 Todo

## Teste Eclipseworks

Para rodar a aplicação é necessário fazer o download do projeto no GitHub.

	https://github.com/quadradosim/Eclipseworks.git

Rodar Back-end
	
	Abra o projeto .Net 8 com o arquivo Eclipseworks.sln. No arquivo appsettings.json altere a string de conexão inserindo seu IPV4.
	Seguindo exemplo abaixo:
	
		Server=SET_YOUR_PC_IPV4,1433;Database=Todo;User Id=sa;Password=Numsey#2021;encrypt=false
		
	Altere a string de conexão apenas onde está escrito "SET_YOUR_PC_IPV4". Para saber seu IPV4 rode o código abaixo no cmd:
	
		ipconfig
	
	No prompt dentro de ".\TestEclipseworks" rode o codigo abaixo para gerar os containers da API e do banco de dados SQL Server.
	
		docker compose up -d
	
	No projeto .Net 8 em Tools/ManageNuggetPackages/ManagePackagesConsole rode o código abaixo para construir a estrutura da base de dados.

		update-database
		
	Após esses passos a aplicação estará rodando no caminho http://localhost:8080. Também é possível rodar a aplicação e ter acesso ao swagger 
	que documenta todos endpoints existentes na API usando Visual Studio ou VS Code.
		
Refinamento
	
	- Qual o objetivo final do software?
	- Número máximo de usuários simultâneos?
	- Períodos de tempestividade?
	- Quais frontends vão usar a API?
	- Existirá alguma forma de integração interna ou com terceiros?
	- Existem planos para melhorias? Quais?

Final
	
	- possíveis pontos de melhoria
	
		implementação de autenticação e segurança usando Gateway
		
		usar Azure Functions ou AWS Lambda para acessar as funcionalidades da API usando serveless reduzindo custos e tendo escalibilidade automática
		
		trocar Get dos relatórios por Dapper usando padrão CQRS para melhorar consultas
		
	- implementação de padrões e visão do projeto sobre arquitetura/cloud
		
		Arquitetura atual da API Restfull

			arquitetura de software
						
				- Arquitetura Monolitica
				- Arquitetura em Camadas
							
			arquitetura de código
						
				- uso de DDD para nomear novas entidades que surjam
				- TDD para garantir que sempre hajam testes para as regras de negócio
				- usar Clean-Code no desenvolvimento
				- seguir Solid Principles no desenvolvimento
				- contar com pipelines automatizadas de deploy no CI/CD usando Azure Devops 
				Pipeline com testes unitários e com SonarCube
				- usar aprovação de pull request no Git, para fazer revisão de código
				- ter uma equipe de QA para testar e montar cenários de testes automatizados
				
		Cloud
		
			A API pode ser colocada dentro de um WebApp da Azure usando o container com a aplicação e o banco de dados.
			Criando regras de escalibilidade horizontal automática e tendo um bom entendimento dos momentos tempestivos
			e do volume usual de trafigo na API para escolher o melhor plano na escala vertical. Caso o software cresça
			é possível mudar o padrão de arquitetura para uma orientação a eventos, usando o serveless. Usando o API 
			Management da Azure para criar um Gateway para as APIS e com coreografação ou orchestração de microserviços 
			e com banco de dados CosmosDB. Na Azure podemos usar as filas ou tópicos abaixo para coreografar os microserviços:
			
				- Storage Queue (fila)
				- Service Bus (fila e tópico)
				- Event Hub (Tópico)
				
			Na Azure podemos usar o serviço do Event Grid para orchestrar os microserviços. Também podemos usar o Azure 
			Devops para gerenciar o projeto com metodologia ágil, guardar documentações e fazer todo CI/CD de pipelines 
			automatizados.
		
		

