sap.ui.define([
	"sap/ui/test/Opa5",
	"./arrangements/Startup",
	"./ListaJornada",
	"./CadastroAnimeJornada",
	"./DetalhesAnimeJornada",
	"./EditarAnimeJornada",
	"./ListaGenerosJornada",
	"./CadastroGeneroJornada",
	"./DetalhesGeneroJornada",
	"./EditarGeneroJornada"
], function (Opa5, 
	Startup,
	ListaJornada,
	CadastroAnimeJornada,
	DetalhesAnimeJornada,
	EditarAnimeJornada,
	ListaGenerosJornada,
	CadastroGeneroJornada,
	DetalhesGeneroJornada,
	EditarGeneroJornada) {
	"use strict";

	Opa5.extendConfig({
		arrangements: new Startup(),
		viewNamespace: "ui5.anime.app",
		autoWait: true
	});
});