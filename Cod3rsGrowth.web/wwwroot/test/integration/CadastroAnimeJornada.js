sap.ui.define([
    "sap/ui/test/opaQunit",
    "./pages/CadastroAnime",
    "./pages/Lista"
], (opaTest,CadastroAnime,Lista) => {
    "use strict";

    QUnit.module("Cadastro anime");
    opaTest("Deve está na tela de cadastro anime", function (Given, When, Then) {
        Given.iStartMyApp({
            hash: "cadastro"
        });
        
        Then
            .onPaginaCadastroAnime
            .aTelaCadastroAnimeFoiCarregadaCorretamente();
    });
    opaTest("Ao tentar cadastrar um anime invalido deve aparecer uma message box de erro", function (Given, When, Then) {
        When
            .onPaginaCadastroAnime
            .aoDigitarNome(`${i18n>anime.nome}`,"Teste")
            .aoDigitarSinopse(`${i18n>anime.sinopse}`,"Teste")
            .aoDigitarNota(`${i18n>anime.nota}`,2)
            .aoClicarNaLista()
            .aoPressionarUmItem("Aventura")
            .aoSelecionarData("20/07/2024")
            .aoClicarNoSelectStatus()
            .aoSelecionarStatus("Previsto")
            .aoClicarEmSalvar();    
        Then
            .onPaginaCadastroAnime
            .deveAperecerUmaMessageBoxDe("Erro")
            .deveFecharMessageBoxAoApertarEmOk("Fechar");
    });
    opaTest("Ao tentar cadastrar um anime válido deve aparecer uma message box de êxito", function (Given, When, Then) {
        When
            .onPaginaCadastroAnime
            .aoDigitarNome(`${i18n>anime.nome}`,"Teste")
            .aoDigitarSinopse(`${i18n>anime.sinopse}`,"Teste")
            .aoDigitarNota(`${i18n>anime.nota}`,2)
            .aoClicarNaLista()
            .aoPressionarUmItem("Drama")
            .aoSelecionarData("20/11/2024")
            .aoClicarNoSelectStatus()
            .aoSelecionarStatus("Previsto")
            .aoClicarEmSalvar();
        Then
            .onPaginaCadastroAnime
            .deveAperecerUmaMessageBoxDe("Êxito")
            .deveFecharMessageBoxAoApertarEmOk("Voltar a lista de anime");
        
    });
    opaTest("Ao clicar em voltar deve navegar para tela anterior", function (Given, When, Then) {
        
        When
            .onPaginaCadastroAnime
            .aoClicarEmVoltar();
        Then
            .onPaginaCadastroAnime
            .DeveSairDaTelaDeCadastro("Cadastro de Anime");

        Then.iTeardownMyApp();
    });
}
);