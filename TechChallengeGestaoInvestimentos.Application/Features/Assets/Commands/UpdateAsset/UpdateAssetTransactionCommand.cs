﻿using MediatR;
using System.Text.Json.Serialization;
using TechChallengeGestaoInvestimentos.Domain.Enum;

namespace TechChallengeGestaoInvestimentos.Application.Features.Assets.Commands.UpdateAsset
{
    public class UpdateAssetTransactionCommand : IRequest
    {
        public Guid AssetId { get; set; }
        public Guid PortfolioId { get; set; }
        [JsonIgnore]
        public TransactionType TransactionType { get; set; }
        [JsonIgnore]
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
