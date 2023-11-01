﻿/* Copyright 2010-present MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

namespace MongoDB.Driver.Linq.Linq3Implementation.Ast
{
    internal enum AstNodeType
    {
        AccumulatorField,
        AddFieldsStage,
        AllFilterOperation,
        AndFilter,
        BinaryExpression,
        BinaryWindowExpression,
        BitsAllClearFilterOperation,
        BitsAllSetFilterOperation,
        BitsAnyClearFilterOperation,
        BitsAnySetFilterOperation,
        BucketAutoStage,
        BucketStage,
        CollStatsStage,
        ComparisonFilterOperation,
        ComputedArrayExpression,
        ComputedDocumentExpression,
        ComputedField,
        CondExpression,
        ConstantExpression,
        ConvertExpression,
        CountStage,
        CurrentOpStage,
        CustomAccumulatorExpression,
        DateAddExpression,
        DateDiffExpression,
        DateFromIsoWeekPartsExpression,
        DateFromPartsExpression,
        DateFromStringExpression,
        DatePartExpression,
        DateSubtractExpression,
        DateToPartsExpression,
        DateToStringExpression,
        DateTruncExpression,
        DensifyStage,
        DerivativeOrIntegralWindowExpression,
        DocumentsStage,
        ElemMatchFilterOperation,
        ExistsFilterOperation,
        ExponentialMovingAverageWindowExpression,
        ExprFilter,
        FacetStage,
        FacetStageFacet,
        FieldOperationFilter,
        FieldPathExpression,
        FilterExpression,
        FilterField,
        FindProjection,
        FunctionExpression,
        GeoIntersectsFilterOperation,
        GeoNearStage,
        GeoWithinBoxFilterOperation,
        GeoWithinCenterFilterOperation,
        GeoWithinCenterSphereFilterOperation,
        GeoWithinFilterOperation,
        GetFieldExpression,
        GraphLookupStage,
        GroupStage,
        ImpliedOperationFilterOperation,
        IndexOfArrayExpression,
        IndexOfBytesExpression,
        IndexOfCPExpression,
        IndexStatsStage,
        InFilterOperation,
        JsonSchemaFilter,
        LetExpression,
        LimitStage,
        ListLocalSessionsStage,
        ListSessionsStage,
        LookupStage,
        LookupStageEqualityMatch,
        LookupStageUncorrelatedMatch,
        LTrimExpression,
        MapExpression,
        MatchesEverythingFilter,
        MatchesNothingFilter,
        MatchStage,
        MergeStage,
        ModFilterOperation,
        NaryExpression,
        NearFilterOperation,
        NearSphereFilterOperation,
        NinFilterOperation,
        NorFilter,
        NotFilterOperation,
        NullaryWindowExpression,
        OrFilter,
        OutStage,
        PickAccumulatorExpression,
        PickExpression,
        Pipeline,
        PlanCacheStatsStage,
        ProjectStage,
        ProjectStageExcludeFieldSpecification,
        ProjectStageIncludeFieldSpecification,
        ProjectStageSetFieldSpecification,
        RangeExpression,
        RawFilter,
        RedactStage,
        ReduceExpression,
        RegexFilterOperation,
        RegexExpression,
        ReplaceAllExpression,
        ReplaceOneExpression,
        ReplaceRootStage,
        ReplaceWithStage,
        RTrimExpression,
        SampleStage,
        SetStage,
        SetWindowFieldsStage,
        ShiftWindowExpression,
        SizeFilterOperation,
        SkipStage,
        SliceExpression,
        SortArrayExpression,
        SortStage,
        SortByCountStage,
        SwitchExpression,
        SwitchExpressionBranch,
        TernaryExpression,
        TextFilter,
        TrimExpression,
        TypeFilterOperation,
        UnaryAccumulatorExpression,
        UnaryExpression,
        UnaryWindowExpression,
        UnionWithStage,
        UniversalStage,
        UnsetStage,
        UnwindStage,
        VarBinding,
        VarExpression,
        WhereFilter,
        WindowField,
        ZipExpression
    }
}
