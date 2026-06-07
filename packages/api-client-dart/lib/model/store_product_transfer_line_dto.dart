//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/model_null.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'store_product_transfer_line_dto.g.dart';

abstract class StoreProductTransferLineDto implements Built<StoreProductTransferLineDto, StoreProductTransferLineDtoBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'productId')
    String get productId;

    @BuiltValueField(wireName: r'quantity')
    int get quantity;

    @nullable
    @BuiltValueField(wireName: r'receivedQuantity')
    int get receivedQuantity;

    @nullable
    @BuiltValueField(wireName: r'unit')
    OneOfnullinteger get unit;

    @nullable
    @BuiltValueField(wireName: r'unitPrice')
    double get unitPrice;

    StoreProductTransferLineDto._();

    static void _initializeBuilder(StoreProductTransferLineDtoBuilder b) => b;

    factory StoreProductTransferLineDto([void updates(StoreProductTransferLineDtoBuilder b)]) = _$StoreProductTransferLineDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<StoreProductTransferLineDto> get serializer => _$StoreProductTransferLineDtoSerializer();
}

class _$StoreProductTransferLineDtoSerializer implements StructuredSerializer<StoreProductTransferLineDto> {

    @override
    final Iterable<Type> types = const [StoreProductTransferLineDto, _$StoreProductTransferLineDto];
    @override
    final String wireName = r'StoreProductTransferLineDto';

    @override
    Iterable<Object> serialize(Serializers serializers, StoreProductTransferLineDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'id')
            ..add(serializers.serialize(object.id,
                specifiedType: const FullType(String)));
        result
            ..add(r'productId')
            ..add(serializers.serialize(object.productId,
                specifiedType: const FullType(String)));
        result
            ..add(r'quantity')
            ..add(serializers.serialize(object.quantity,
                specifiedType: const FullType(int)));
        result
            ..add(r'receivedQuantity')
            ..add(object.receivedQuantity == null ? null : serializers.serialize(object.receivedQuantity,
                specifiedType: const FullType(int)));
        result
            ..add(r'unit')
            ..add(object.unit == null ? null : serializers.serialize(object.unit,
                specifiedType: const FullType(OneOfnullinteger)));
        result
            ..add(r'unitPrice')
            ..add(object.unitPrice == null ? null : serializers.serialize(object.unitPrice,
                specifiedType: const FullType(double)));
        return result;
    }

    @override
    StoreProductTransferLineDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = StoreProductTransferLineDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'id':
                    result.id = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'productId':
                    result.productId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'quantity':
                    result.quantity = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'receivedQuantity':
                    result.receivedQuantity = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'unit':
                    result.unit.replace(serializers.deserialize(value,
                        specifiedType: const FullType(OneOfnullinteger)) as OneOfnullinteger);
                    break;
                case r'unitPrice':
                    result.unitPrice = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
            }
        }
        return result.build();
    }
}

