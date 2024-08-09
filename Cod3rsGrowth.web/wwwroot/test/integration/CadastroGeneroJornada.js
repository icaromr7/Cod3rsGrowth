sap.ui.define([
	"sap/ui/test/opaQunit",
    "./pages/CadastroGenero",
	"./pages/ListaGeneros",
], (opaTest,CadastroGenero,ListaGeneros) => {
	"use strict";

	QUnit.module("Cadastro gênero");

	opaTest("Deve está na tela de cadastro gênero", function (Given, When, Then) {
        Given.iStartMyApp({
            hash: "genero/cadastro"
        });
        
        Then
            .onPaginaCadastroGenero
            .aTelaCadastroGeneroFoiCarregadaCorretamente();
    });

    opaTest("Ao tentar cadastrar um gênero invalido deve aparecer uma message box de erro", function(Given, When, Then){
		
        When
			.onPaginaCadastroGenero
			.aoDigitarNome("Drama")
			.aoClicarEmSalvar();
        
		Then
			.onPaginaCadastroGenero
			.deveAperecerUmaMessageBoxDe("Erro")
			.deveFecharMessageBoxAoApertarEmOk("Fechar");
	});
    opaTest("Ao tentar cadastrar um gênero válido deve aparecer uma message box de êxito", function(Given, When, Then){

        When
			.onPaginaCadastroGenero
			.aoDigitarNome("Familia")
			.aoClicarEmSalvar();

		Then
			.onPaginaCadastroGenero
			.deveAperecerUmaMessageBoxDe("Êxito")
			.deveFecharMessageBoxAoApertarEmOk("Voltar a lista de gêneros");

	});
	opaTest("Ao clicar em voltar deve navegar para tela anterior", function (Given, When, Then) {
        
        When
            .onPaginaCadastroGenero
            .aoClicarEmVoltar();

        Then
            .onPaginaCadastroGenero
            .DeveSairDaTelaDeCadastro("Cadastro de Gênero");

        Then.iTeardownMyApp();
    });
	
}
);