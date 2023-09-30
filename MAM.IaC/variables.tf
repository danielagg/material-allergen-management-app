variable "subscription_id" {
  description = "Azure Subscription ID"
}

variable "client_id" {
  description = "Azure Service Principal Client/App ID (from AAD/Entra)"
}

variable "client_secret" {
  description = "Azure Service Principal Client Secret (from AAD/Entra)"
}

variable "tenant_id" {
  description = "Azure Tenant ID"
}

variable "resource_group_name" {
  description = "Name of the Azure Resource Group to create"
  type        = string
  default     = "material-allergen-management"
}