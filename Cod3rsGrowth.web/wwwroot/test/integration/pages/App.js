sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press"
], (Opa5, Press) => {
	"use strict";

	const sNomeDaTela = "ui5.anime.appcontrollerview.App";

	Opa5.createPageObjects({
		onAppPagina: {
			actions: {
				AoPressionarBotaoBemVindo() {
					return this.waitFor({
						id: "btnBemVindo",
						viewName: sNomeDaTela,
						actions: new Press(),
						errorMessage: "Não foi encontrado o botão 'Diga Bem Vindo com caixa de diálogo' na visualização App"
					});
				}
			},

			assertions: {
				AoMostarDialogoBemVindo() {
					return this.waitFor({
						controlType: "sap.m.Dialog",
						success() {
							Opa5.assert.ok(true, "A caixa de diálogo está aberta");
						},
						errorMessage: "Não encontrei o controle de diálogo"
					});
				}
			}
		}
	});
});