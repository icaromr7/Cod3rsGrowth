sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/Lista",
	"./pages/ListaGeneros"
], (opaTest) => {
	"use strict";

	QUnit.module("Lista de gêneros");

	opaTest("Deve ser capaz de mostrar todos os itens",  function(Given, When, Then) {
		//Arrangements
        Given.iStartMyApp({
            hash: "generos"
        });
		//Actions
		When.onPaginaListaGeneros.aoApertarEmMais();

		//Assertions
		Then.onPaginaListaGeneros.aListaDeveMostrarMaisGeneros();
	})
	opaTest("Deve ser capaz de pesquisar itens", function(Given, When, Then)  {
		
		//Actions
		When.onPaginaListaGeneros.aoPesquisarPorNome("Av");

		// Assertions
		Then.onPaginaListaGeneros.aListaTemUmGenero();

	});

	opaTest("Ao clicar em adicionar gênero deve navegar para tela de cadastro", function (Given, When, Then) {
        
		//Actions
        When.onPaginaListaGeneros.aoApertarEmAdicionarGênero();

		// Assertions
		Then.onPaginaCadastroGenero.deveNavegarParaTelaDeCadastro();
		
		// Cleanup
		Then.iTeardownMyApp();
	});

	opaTest("Ao clicar no gênero deve navegar para tela de detalhes", function (Given, When, Then) {
		// Arrangements
		Given.iStartMyApp({
            hash: "generos"
        });

        //Actions
        When.onPaginaListaGeneros.aoClicarEmUmGenero("Aventura");

		// Assertions
		Then.onPaginaDetalhesGenero.deveNavegarParaTelaDeDetalhes();

		// Cleanup
		Then.iTeardownMyApp();
	});
	opaTest("Ao clicar em voltar deve navegar para tela anterior", function (Given, When, Then) {
        //Arrangements
        Given.iStartMyApp({
            hash: "generos"
        });
        //Actions
        When.onPaginaListaGeneros.aoClicarEmVoltar();
		// Assertions
        Then.onPaginaListaGeneros.deveVoltarParaTelaAnterior();

        // Cleanup
		Then.iTeardownMyApp();
        
	});
	
});