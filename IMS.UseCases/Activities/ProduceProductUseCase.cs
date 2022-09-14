﻿using IMS.CoreBusiness;
using IMS.UseCases.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Activities
{
    public class ProduceProductUseCase : IProduceProductUseCase
    {
        private readonly IInventoryRepository inventoryRepository;
        private readonly IProductRepository productRepository;
        private readonly IInventoryTransactionRepository inventoryTransactionRepository;
        private readonly IProductTransactionRepository productTransactionRepository;

        public ProduceProductUseCase(
            IInventoryRepository inventoryRepository,
            IProductRepository productRepository,
            IInventoryTransactionRepository inventoryTransactionRepository,
            IProductTransactionRepository productTransactionRepository)
        {
            this.inventoryRepository = inventoryRepository;
            this.productRepository = productRepository;
            this.inventoryTransactionRepository = inventoryTransactionRepository;
            this.productTransactionRepository = productTransactionRepository;
        }
        public async Task ExecuteAsync(string productionNumber, Product product, int quantity, string doneBy)
        {
            await productTransactionRepository.ProduceAsync(productionNumber, product, quantity, product.Price, doneBy);

            product.Quantity += quantity;
            await productRepository.UpdateProductAsync(product);

        }

        public Task ExecuteAsync(string productionNumber, Product product, int quantity, double price, string doneBy)
        {
            throw new NotImplementedException();
        }
    }
}
