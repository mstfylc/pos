//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/stock_movement_dto.dart';
import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'paged_result_of_stock_movement_dto.g.dart';

abstract class PagedResultOfStockMovementDto implements Built<PagedResultOfStockMovementDto, PagedResultOfStockMovementDtoBuilder> {

    @BuiltValueField(wireName: r'items')
    BuiltList<StockMovementDto> get items;

    @BuiltValueField(wireName: r'page')
    int get page;

    @BuiltValueField(wireName: r'pageSize')
    int get pageSize;

    @BuiltValueField(wireName: r'totalCount')
    int get totalCount;

    @BuiltValueField(wireName: r'totalPages')
    int get totalPages;

    PagedResultOfStockMovementDto._();

    static void _initializeBuilder(PagedResultOfStockMovementDtoBuilder b) => b;

    factory PagedResultOfStockMovementDto([void updates(PagedResultOfStockMovementDtoBuilder b)]) = _$PagedResultOfStockMovementDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<PagedResultOfStockMovementDto> get serializer => _$PagedResultOfStockMovementDtoSerializer();
}

class _$PagedResultOfStockMovementDtoSerializer implements StructuredSerializer<PagedResultOfStockMovementDto> {

    @override
    final Iterable<Type> types = const [PagedResultOfStockMovementDto, _$PagedResultOfStockMovementDto];
    @override
    final String wireName = r'PagedResultOfStockMovementDto';

    @override
    Iterable<Object> serialize(Serializers serializers, PagedResultOfStockMovementDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'items')
            ..add(serializers.serialize(object.items,
                specifiedType: const FullType(BuiltList, [FullType(StockMovementDto)])));
        result
            ..add(r'page')
            ..add(serializers.serialize(object.page,
                specifiedType: const FullType(int)));
        result
            ..add(r'pageSize')
            ..add(serializers.serialize(object.pageSize,
                specifiedType: const FullType(int)));
        result
            ..add(r'totalCount')
            ..add(serializers.serialize(object.totalCount,
                specifiedType: const FullType(int)));
        result
            ..add(r'totalPages')
            ..add(serializers.serialize(object.totalPages,
                specifiedType: const FullType(int)));
        return result;
    }

    @override
    PagedResultOfStockMovementDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = PagedResultOfStockMovementDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'items':
                    result.items.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(StockMovementDto)])) as BuiltList<StockMovementDto>);
                    break;
                case r'page':
                    result.page = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'pageSize':
                    result.pageSize = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'totalCount':
                    result.totalCount = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'totalPages':
                    result.totalPages = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
            }
        }
        return result.build();
    }
}

