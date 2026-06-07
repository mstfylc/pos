//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'loyalty_preview_line.g.dart';

abstract class LoyaltyPreviewLine implements Built<LoyaltyPreviewLine, LoyaltyPreviewLineBuilder> {

    @BuiltValueField(wireName: r'productId')
    String get productId;

    @BuiltValueField(wireName: r'quantity')
    int get quantity;

    @BuiltValueField(wireName: r'unitPrice')
    double get unitPrice;

    @BuiltValueField(wireName: r'taxAmount')
    double get taxAmount;

    LoyaltyPreviewLine._();

    static void _initializeBuilder(LoyaltyPreviewLineBuilder b) => b
        ..taxAmount = '0';

    factory LoyaltyPreviewLine([void updates(LoyaltyPreviewLineBuilder b)]) = _$LoyaltyPreviewLine;

    @BuiltValueSerializer(custom: true)
    static Serializer<LoyaltyPreviewLine> get serializer => _$LoyaltyPreviewLineSerializer();
}

class _$LoyaltyPreviewLineSerializer implements StructuredSerializer<LoyaltyPreviewLine> {

    @override
    final Iterable<Type> types = const [LoyaltyPreviewLine, _$LoyaltyPreviewLine];
    @override
    final String wireName = r'LoyaltyPreviewLine';

    @override
    Iterable<Object> serialize(Serializers serializers, LoyaltyPreviewLine object,
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
        result
            ..add(r'unitPrice')
            ..add(serializers.serialize(object.unitPrice,
                specifiedType: const FullType(double)));
        if (object.taxAmount != null) {
            result
                ..add(r'taxAmount')
                ..add(serializers.serialize(object.taxAmount,
                    specifiedType: const FullType(double)));
        }
        return result;
    }

    @override
    LoyaltyPreviewLine deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = LoyaltyPreviewLineBuilder();

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
                case r'unitPrice':
                    result.unitPrice = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'taxAmount':
                    result.taxAmount = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
            }
        }
        return result.build();
    }
}

