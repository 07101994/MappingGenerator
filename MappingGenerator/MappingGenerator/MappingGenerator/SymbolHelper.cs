﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace MappingGenerator
{
    internal static class SymbolHelper
    {
        public static bool IsUpdateParameterFunction(IMethodSymbol methodSymbol)
        {
            return methodSymbol.Parameters.Length == 2 && methodSymbol.ReturnsVoid;
        }

        public static bool IsUpdateThisObjectFunction(IMethodSymbol methodSymbol)
        {
            return methodSymbol.Parameters.Length == 1 && methodSymbol.ReturnsVoid;
        }

        public static bool IsPureMappingFunction(IMethodSymbol methodSymbol)
        {
            return methodSymbol.Parameters.Length == 1 && methodSymbol.ReturnsVoid == false;
        }

        public static bool IsMappingConstructor(IMethodSymbol methodSymbol)
        {
            return methodSymbol.Parameters.Length == 1 && methodSymbol.MethodKind == MethodKind.Constructor;
        }

        public static IEnumerable<ITypeSymbol> UnwrapGeneric(this ITypeSymbol typeSymbol)
        {
            if (typeSymbol.TypeKind == TypeKind.TypeParameter && typeSymbol is ITypeParameterSymbol namedType && namedType.Kind != SymbolKind.ErrorType)
            {
                return namedType.ConstraintTypes;
            }
            return new []{typeSymbol};
        }
    }
}