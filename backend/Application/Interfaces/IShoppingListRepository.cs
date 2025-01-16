﻿using Domain.DomainModels;

namespace Application.Interfaces
{
    public interface IShoppingListRepository  // An interface defines the signature (method names, parameters, return types) of methods, while the class that implements the interface provides the specific implementation of those methods (ShoppingListRepository)
    {
        Task<IEnumerable<ShoppingList>> GetShoppingLists();  // get all shopping lists

        Task<IEnumerable<ShoppingList>> GetShoppingListsByShopperId(int shopperId);  // get shopping lists by shopper id

        Task DeleteShoppingList(int id);
    }
}