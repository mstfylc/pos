//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'receive_transfer_line.g.dart';

abstract class ReceiveTransferLine implements Built<ReceiveTransferLine, ReceiveTransferLineBuilder> {

    @BuiltValueField(wireName: r'productId')
    String get productId;

    @BuiltValueField(wireName: r'receivedQuantity')
    int get receivedQuantity;

    ReceiveTransferLine._();

    static void _initializeBuilder(ReceiveTransferLineBuilder b) => b;

    factory ReceiveTransferLine([void updates(ReceiveTransferLineBuilder b)]) = _$ReceiveTransferLine;

    @BuiltValueSerializer(custom: true)
    static Serializer<ReceiveTransferLine> get serializer => _$ReceiveTransferLineSerializer();
}

class _$ReceiveTransferLineSerializer implements StructuredSerializer<ReceiveTransferLine> {

    @override
    final Iterable<Type> types = const [ReceiveTransferLine, _$ReceiveTransferLine];
    @override
    final String wireName = r'ReceiveTransferLine';

    @override
    Iterable<Object> serialize(Serializers serializers, ReceiveTransferLine object,
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
    ReceiveTransferLine deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = ReceiveTransferLineBuilder();

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

