sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/ListaGeneros",
	"./pages/Lista",
	"./pages/CadastroGenero",
	"./pages/DetalhesGenero"
], (opaTest,ListaGeneros,Lista,CadastroGenero,DetalhesGenero) => {
	"use strict";

	QUnit.module("Lista de gêneros");
	opaTest("Deve está na tela de lista de gênero", function (Given, When, Then) {
        Given.iStartMyApp({
            hash: "generos"
        });
        
        Then
            .onPaginaListaGeneros
            .aTelaListaDeGenerosFoiCarregadaCorretamente();
    });
	opaTest("Deve ser capaz de mostrar todos os itens",  function(Given, When, Then) {
        
		When
			.onPaginaListaGeneros
			.aoApertarEmMais();

		Then
			.onPaginaListaGeneros
			.aListaDeveMostrarMaisGeneros();
	})
	opaTest("Deve ser capaz de pesquisar itens", function(Given, When, Then)  {
		
		When
			.onPaginaListaGeneros
			.aoPesquisarPorNome("Av");
		Then
			.onPaginaListaGeneros
			.aListaTemUmGenero();

	});

	opaTest("Ao clicar em adicionar gênero deve navegar para tela de cadastro", function (Given, When, Then) {
        
        When
			.onPaginaListaGeneros
			.aoApertarEmAdicionarGênero();
		Then
			.onPaginaCadastroGenero
			.aTelaCadastroGeneroFoiCarregadaCorretamente();
		When
			.onPaginaCadastroGenero
			.aoClicarEmVoltar();
		
	});
	opaTest("Ao clicar no gênero deve navegar para tela de detalhes", function (Given, When, Then) {
		
        When
			.onPaginaListaGeneros
			.aoClicarEmUmGenero("Aventura");
		Then
			.onPaginaDetalhesGenero
			.aTelaDetalhesGeneroFoiCarregadaCorretamente();
		When
			.onPaginaDetalhesGenero
			.aoClicarEmVoltar();
	});
	opaTest("Ao clicar em voltar deve navegar para tela anterior", function (Given, When, Then) {
        
        When
            .onPaginaListaGeneros
            .aoClicarEmVoltar();
        Then
            .onPaginaListaGeneros
            .DeveSairDaTelaDeCadastro("Lista de Gêneros");

        Then.iTeardownMyApp();
    });
});