1 . Executar a aplica��o da API 

	Na solution clique com o bot�o direito do mouse no projeto B3CalculoCDB e Selecione Configure Startup Project
	
	Pressione a tecla F5 ou clique em "Iniciar Depura��o" no Visual Studio para executar a aplica��o.


2. Para executar o c�digo do projeto Angular no PowerShell, siga os passos abaixo:

	Abra o PowerShell no diret�rio raiz do seu projeto Angular (onde est� localizado o arquivo angular.json).
	
	Execute o comando abaixo para instalar as depend�ncias do projeto (isso s� precisa ser feito uma vez ap�s clonar o projeto ou sempre que as depend�ncias forem atualizadas):

	npm install
	
	Ap�s a instala��o das depend�ncias, voc� pode executar o comando abaixo para iniciar o servidor de desenvolvimento:

	ng serve
	
	O servidor de desenvolvimento do Angular ser� iniciado e a aplica��o estar� dispon�vel em http://localhost:4200/. Abra seu navegador e acesse esse endere�o para ver a aplica��o funcionando.

	Se voc� fizer altera��es no c�digo-fonte enquanto o servidor estiver em execu��o, o Angular CLI ir� automaticamente recarregar a p�gina para refletir as altera��es.
	
	Para interromper a execu��o do servidor de desenvolvimento, pressione Ctrl + C no terminal onde o comando ng serve est� sendo executado.
	
	Esses passos permitir�o que voc� execute o projeto Angular e visualize a p�gina da aplica��o localmente no seu navegador atrav�s do servidor de desenvolvimento do Angular CLI.


3. Executar os testes

	Para executar os testes, clique com o bot�o direito do mouse no projeto B3CalculoCDB.Tests no Solution Explorer e selecione "Executar Teste	s".

	Ap�s a execu��o, voc� ver� os resultados dos testes no "Explorador de Testes" ou no "Gerenciador de Testes" no Visual Studio.

	Os testes bem-sucedidos ser�o exibidos em verde, enquanto os testes falhados ser�o exibidos em vermelho.