resource "azurerm_resource_group" "main-resource-group" {
  name     = var.resource_group_name
  location = "West EU"
}