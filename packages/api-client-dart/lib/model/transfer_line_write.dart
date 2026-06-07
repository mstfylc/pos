//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/product_unit_type.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'transfer_line_write.g.dart';

abstract class TransferLineWrite implements Built<TransferLineWrite, TransferLineWriteBuilder> {

    @BuiltValueField(wireName: r'productId')
    String get productId;

    @BuiltValueField(wireName: r'quantity')
    int get quantity;

    @nullable
    @BuiltValueField(wireName: r'unit')
    ProductUnitType get unit;
    // enum unitEnum {  Adet,  MiliLitre,  Gram,  };

    @nullable
    @BuiltValueField(wireName: r'unitPrice')
    double get unitPrice;

    TransferLineWrite._();

    static void _initializeBuilder(TransferLineWriteBuilder b) => b;

    factory TransferLineWrite([void updates(TransferLineWriteBuilder b)]) = _$TransferLineWrite;

    @BuiltValueSerializer(custom: true)
    static Serializer<TransferLineWrite> get serializer => _$TransferLineWriteSerializer();
}

class _$TransferLineWriteSerializer implements StructuredSerializer<TransferLineWrite> {

    @override
    final Iterable<Type> types = const [TransferLineWrite, _$TransferLineWrite];
    @override
    final String wireName = r'TransferLineWrite';

    @override
    Iterable<Object> serialize(Serializers serializers, TransferLineWrite object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'productId')
            ..add(serializers.serialize(object.productId,
                specifiedType: const FullType(String)));
        result
            ..add(r'quantity')
            ..add(serializers.serialize(object.quantity,
                specifiedType: const FullType(int)));
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
    TransferLineWrite deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = TransferLineWriteBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'productId':
                    result.productId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'quantity':
                    result.quantity = serializers.deserialize(value,
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

