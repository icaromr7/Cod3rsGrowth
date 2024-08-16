sap.ui.define([
	"sap/ui/test/opaQunit",
    "./pages/EditarGenero",
	"./pages/ListaGeneros",
	"./pages/Lista"
], (opaTest,EditarGenero,ListaGeneros,Lista) => {
	"use strict";

	QUnit.module("Editar gênero");
	opaTest("Deve está na tela de editar gênero", function (Given, When, Then) {
        Given.iStartMyApp({
			hash: "genero/editar/37"
		});
        Then
            .onPaginaEditarGenero
            .aTelaEditarGeneroFoiCarregadaCorretamente();
    });
    opaTest("Na tela deve conter as informações corretas do item clicado", function (Given, When, Then) {
		
        Then
			.onPaginaEditarGenero
			.deveTerOIdDoItemSelecionado("37")
			.deveTerONomeDoItemSelecionado("Amizade");
        
	});
    opaTest("Ao tentar editar um gênero invalido deve aparecer uma message box de erro", function(Given, When, Then){
        When
			.onPaginaEditarGenero
			.aoDigitarNome("Drama")
			.aoClicarEmSalvar();
		Then
			.onPaginaEditarGenero
			.deveAperecerUmaMessageBoxDe("Erro")
			.deveFecharMessageBoxAoApertarEmOk("Fechar");
	});
    opaTest("Ao tentar editar um gênero válido deve aparecer uma message box de êxito", function(Given, When, Then){
        When
			.onPaginaEditarGenero
			.aoDigitarNome("Familia")
			.aoClicarEmSalvar();
		Then
			.onPaginaEditarGenero
			.deveAperecerUmaMessageBoxDe("Êxito")
			.deveFecharMessageBoxAoApertarEmOk("Voltar a lista de gêneros");
	});
}
);