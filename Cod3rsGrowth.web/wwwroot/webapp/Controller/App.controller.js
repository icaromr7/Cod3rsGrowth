sap.ui.define([
"sap/ui/core/mvc/Controller",
"sap/ui/model/resource/ResourceModel"
], (Controller, ResourceModel) => {
"use strict";

return Controller.extend("ui5.anime.controller.App", {
    onInit(){
        const i18nModel = new ResourceModel({
            bundleName: "ui5.anime.i18n.i18n"
        });
        this.getView().setModel(i18nModel, "i18n");
    },

    onBemVindo() {
        var msg = this.getView().getModel("i18n").getResourceBundle().getText("bemVindoMsg");
        alert(msg);
    }
});
});