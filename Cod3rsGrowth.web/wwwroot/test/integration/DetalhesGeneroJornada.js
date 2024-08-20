sap.ui.define([
	"sap/ui/test/opaQunit",
    "./pages/DetalhesGenero",
	"./pages/ListaGeneros",
	"./pages/Lista"
], (opaTest,DetalhesGenero,ListaGeneros,Lista) => {
	"use strict";

	QUnit.module("Detalhes gênero");
	opaTest("Deve está na tela de detalhes gênero", function (Given, When, Then) {
        Given.iStartMyApp({
			hash: "genero/36"
		});

        Then
            .onPaginaDetalhesGenero
            .aTelaDetalhesGeneroFoiCarregadaCorretamente();
    });
    opaTest("Na tela deve conter as informações corretas do item clicado", function (Given, When, Then) {
		
        Then
			.onPaginaDetalhesGenero
			.deveTerOIdDoItemSelecionado("36")
			.deveTerONomeDoItemSelecionado("Ninja");
        
	});
    opaTest("Ao clicar em editar deve navegar para tela de edição", function (Given, When, Then) {
        When
            .onPaginaDetalhesGenero
            .aoClicarEmEditar();
        Then
            .onPaginaEditarGenero
            .aTelaEditarGeneroFoiCarregadaCorretamente();
        Then
            .iTeardownMyApp();
    });
	opaTest("Ao clicar em voltar deve navegar para tela anterior", function (Given, When, Then) {
        Given.iStartMyApp({
			hash: "genero/36"
		});
        When
            .onPaginaDetalhesGenero
            .aoClicarEmVoltar();
        Then
            .onPaginaListaGeneros
            .aTelaListaDeGenerosFoiCarregadaCorretamente();
        
        Then
            .iTeardownMyApp();
    });
    opaTest("Ao clicar em não deve fechar a mensagem box", function (Given, When, Then) {
        Given.iStartMyApp({
            hash: "genero/36"
        });
        When
            .onPaginaDetalhesDoAnime
            .aoClicarEmRemover();
        Then
            .onPaginaDetalhesDoAnime
            .deveAperecerUmaMessageBoxDe("Confirmação")
            .deveFecharMessageBoxAoApertarEmOk("Não");
    });
    opaTest("Ao clicar em sim deve fechar a mensagem box", function (Given, When, Then) {       
        When
            .onPaginaDetalhesDoAnime
            .aoClicarEmRemover();
        Then
            .onPaginaDetalhesDoAnime
            .deveAperecerUmaMessageBoxDe("Confirmação")
            .deveFecharMessageBoxAoApertarEmOk("Sim");
        Then
            .iTeardownMyApp();
    });
}
);