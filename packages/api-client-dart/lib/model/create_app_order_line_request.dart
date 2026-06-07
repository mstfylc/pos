//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'create_app_order_line_request.g.dart';

abstract class CreateAppOrderLineRequest implements Built<CreateAppOrderLineRequest, CreateAppOrderLineRequestBuilder> {

    @BuiltValueField(wireName: r'productId')
    String get productId;

    @BuiltValueField(wireName: r'quantity')
    int get quantity;

    @BuiltValueField(wireName: r'unitPrice')
    double get unitPrice;

    @BuiltValueField(wireName: r'taxAmount')
    double get taxAmount;

    @BuiltValueField(wireName: r'isEntry')
    bool get isEntry;

    CreateAppOrderLineRequest._();

    static void _initializeBuilder(CreateAppOrderLineRequestBuilder b) => b
        ..taxAmount = 0
        ..isEntry = false;

    factory CreateAppOrderLineRequest([void updates(CreateAppOrderLineRequestBuilder b)]) = _$CreateAppOrderLineRequest;

    @BuiltValueSerializer(custom: true)
    static Serializer<CreateAppOrderLineRequest> get serializer => _$CreateAppOrderLineRequestSerializer();
}

class _$CreateAppOrderLineRequestSerializer implements StructuredSerializer<CreateAppOrderLineRequest> {

    @override
    final Iterable<Type> types = const [CreateAppOrderLineRequest, _$CreateAppOrderLineRequest];
    @override
    final String wireName = r'CreateAppOrderLineRequest';

    @override
    Iterable<Object> serialize(Serializers serializers, CreateAppOrderLineRequest object,
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
        if (object.isEntry != null) {
            result
                ..add(r'isEntry')
                ..add(serializers.serialize(object.isEntry,
                    specifiedType: const FullType(bool)));
        }
        return result;
    }

    @override
    CreateAppOrderLineRequest deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CreateAppOrderLineRequestBuilder();

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
                case r'isEntry':
                    result.isEntry = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
            }
        }
        return result.build();
    }
}

