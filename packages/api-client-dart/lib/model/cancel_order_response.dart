//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/order_state.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'cancel_order_response.g.dart';

abstract class CancelOrderResponse implements Built<CancelOrderResponse, CancelOrderResponseBuilder> {

    @BuiltValueField(wireName: r'orderId')
    String get orderId;

    @BuiltValueField(wireName: r'orderState')
    OrderState get orderState;
    // enum orderStateEnum {  Received,  Preparing,  Completed,  Cancelled,  Deleted,  Transferring,  };

    @BuiltValueField(wireName: r'existing')
    bool get existing;

    CancelOrderResponse._();

    static void _initializeBuilder(CancelOrderResponseBuilder b) => b;

    factory CancelOrderResponse([void updates(CancelOrderResponseBuilder b)]) = _$CancelOrderResponse;

    @BuiltValueSerializer(custom: true)
    static Serializer<CancelOrderResponse> get serializer => _$CancelOrderResponseSerializer();
}

class _$CancelOrderResponseSerializer implements StructuredSerializer<CancelOrderResponse> {

    @override
    final Iterable<Type> types = const [CancelOrderResponse, _$CancelOrderResponse];
    @override
    final String wireName = r'CancelOrderResponse';

    @override
    Iterable<Object> serialize(Serializers serializers, CancelOrderResponse object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'orderId')
            ..add(serializers.serialize(object.orderId,
                specifiedType: const FullType(String)));
        result
            ..add(r'orderState')
            ..add(serializers.serialize(object.orderState,
                specifiedType: const FullType(OrderState)));
        result
            ..add(r'existing')
            ..add(serializers.serialize(object.existing,
                specifiedType: const FullType(bool)));
        return result;
    }

    @override
    CancelOrderResponse deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CancelOrderResponseBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'orderId':
                    result.orderId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'orderState':
                    result.orderState = serializers.deserialize(value,
                        specifiedType: const FullType(OrderState)) as OrderState;
                    break;
                case r'existing':
                    result.existing = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
            }
        }
        return result.build();
    }
}

