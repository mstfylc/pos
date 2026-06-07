//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'receive_transfer_line_dto.g.dart';

abstract class ReceiveTransferLineDto implements Built<ReceiveTransferLineDto, ReceiveTransferLineDtoBuilder> {

    @BuiltValueField(wireName: r'productId')
    String get productId;

    @BuiltValueField(wireName: r'receivedQuantity')
    int get receivedQuantity;

    ReceiveTransferLineDto._();

    static void _initializeBuilder(ReceiveTransferLineDtoBuilder b) => b;

    factory ReceiveTransferLineDto([void updates(ReceiveTransferLineDtoBuilder b)]) = _$ReceiveTransferLineDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<ReceiveTransferLineDto> get serializer => _$ReceiveTransferLineDtoSerializer();
}

class _$ReceiveTransferLineDtoSerializer implements StructuredSerializer<ReceiveTransferLineDto> {

    @override
    final Iterable<Type> types = const [ReceiveTransferLineDto, _$ReceiveTransferLineDto];
    @override
    final String wireName = r'ReceiveTransferLineDto';

    @override
    Iterable<Object> serialize(Serializers serializers, ReceiveTransferLineDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'productId')
            ..add(serializers.serialize(object.productId,
                specifiedType: const FullType(String)));
        result
            ..add(r'receivedQuantity')
            ..add(serializers.serialize(object.receivedQuantity,
                specifiedType: const FullType(int)));
        return result;
    }

    @override
    ReceiveTransferLineDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = ReceiveTransferLineDtoBuilder();

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
                case r'receivedQuantity':
                    result.receivedQuantity = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
            }
        }
        return result.build();
    }
}

