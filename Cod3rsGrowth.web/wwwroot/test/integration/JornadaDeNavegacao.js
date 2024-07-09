sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/App"
], (opaTest) => {
	"use strict";

	QUnit.module("Navigation");

	opaTest("Mostrar o dialogo de bem vindo", (Given, When, Then) => {
		// Arrangements
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.anime"
			}
		});

		//Actions
		When.onAppPagina.AoPressionarBotaoBemVindo();

		// Assertions
		Then.onAppPagina.AoMostarDialogoBemVindo();

		// Cleanup
		Then.iTeardownMyApp();
	});
});