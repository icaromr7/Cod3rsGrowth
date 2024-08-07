sap.ui.define([
	"sap/ui/test/Opa5",
	"./arrangements/Startup",
	"./ListaJornada",
	"./CadastroAnimeJornada",
	"./DetalhesAnimeJornada",
	"./ListaGenerosJornada",
	"./CadastroGeneroJornada",
	"./DetalhesGeneroJornada"
], function (Opa5, Startup) {
	"use strict";

	Opa5.extendConfig({
		arrangements: new Startup(),
		viewNamespace: "ui5.anime.app",
		autoWait: true
	});
});