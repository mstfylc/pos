//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/product_unit_type.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'store_product_transfer_line.g.dart';

abstract class StoreProductTransferLine implements Built<StoreProductTransferLine, StoreProductTransferLineBuilder> {

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
    ProductUnitType get unit;
    // enum unitEnum {  Adet,  MiliLitre,  Gram,  };

    @nullable
    @BuiltValueField(wireName: r'unitPrice')
    double get unitPrice;

    StoreProductTransferLine._();

    static void _initializeBuilder(StoreProductTransferLineBuilder b) => b;

    factory StoreProductTransferLine([void updates(StoreProductTransferLineBuilder b)]) = _$StoreProductTransferLine;

    @BuiltValueSerializer(custom: true)
    static Serializer<StoreProductTransferLine> get serializer => _$StoreProductTransferLineSerializer();
}

class _$StoreProductTransferLineSerializer implements StructuredSerializer<StoreProductTransferLine> {

    @override
    final Iterable<Type> types = const [StoreProductTransferLine, _$StoreProductTransferLine];
    @override
    final String wireName = r'StoreProductTransferLine';

    @override
    Iterable<Object> serialize(Serializers serializers, StoreProductTransferLine object,
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
        if (object.receivedQuantity != null) {
            result
                ..add(r'receivedQuantity')
                ..add(serializers.serialize(object.receivedQuantity,
                    specifiedType: const FullType(int)));
        }
        if (object.unit != null) {
            result
                ..add(r'unit')
                ..add(serializers.serialize(object.unit,
                    specifiedType: const FullType(ProductUnitType)));
        }
        if (object.unitPrice != null) {
            result
                ..add(r'unitPrice')
                ..add(serializers.serialize(object.unitPrice,
                    specifiedType: const FullType(double)));
        }
        return result;
    }

    @override
    StoreProductTransferLine deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = StoreProductTransferLineBuilder();

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
                    result.unit = serializers.deserialize(value,
                        specifiedType: const FullType(ProductUnitType)) as ProductUnitType;
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

