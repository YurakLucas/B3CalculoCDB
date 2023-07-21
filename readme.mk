1 . Executar a aplicação da API 

	Na solution clique com o botão direito do mouse no projeto B3CalculoCDB e Selecione Configure Startup Project
	
	Pressione a tecla F5 ou clique em "Iniciar Depuração" no Visual Studio para executar a aplicação.


2. Para executar o código do projeto Angular no PowerShell, siga os passos abaixo:

	Abra o PowerShell no diretório raiz do seu projeto Angular (onde está localizado o arquivo angular.json).
	
	Execute o comando abaixo para instalar as dependências do projeto (isso só precisa ser feito uma vez após clonar o projeto ou sempre que as dependências forem atualizadas):

	npm install
	
	Após a instalação das dependências, você pode executar o comando abaixo para iniciar o servidor de desenvolvimento:

	ng serve
	
	O servidor de desenvolvimento do Angular será iniciado e a aplicação estará disponível em http://localhost:4200/. Abra seu navegador e acesse esse endereço para ver a aplicação funcionando.

	Se você fizer alterações no código-fonte enquanto o servidor estiver em execução, o Angular CLI irá automaticamente recarregar a página para refletir as alterações.
	
	Para interromper a execução do servidor de desenvolvimento, pressione Ctrl + C no terminal onde o comando ng serve está sendo executado.
	
	Esses passos permitirão que você execute o projeto Angular e visualize a página da aplicação localmente no seu navegador através do servidor de desenvolvimento do Angular CLI.


3. Executar os testes

	Para executar os testes, clique com o botão direito do mouse no projeto B3CalculoCDB.Tests no Solution Explorer e selecione "Executar Teste	s".

	Após a execução, você verá os resultados dos testes no "Explorador de Testes" ou no "Gerenciador de Testes" no Visual Studio.

	Os testes bem-sucedidos serão exibidos em verde, enquanto os testes falhados serão exibidos em vermelho.