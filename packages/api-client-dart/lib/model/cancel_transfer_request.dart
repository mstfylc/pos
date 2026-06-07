//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'cancel_transfer_request.g.dart';

abstract class CancelTransferRequest implements Built<CancelTransferRequest, CancelTransferRequestBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'reason')
    String get reason;

    CancelTransferRequest._();

    static void _initializeBuilder(CancelTransferRequestBuilder b) => b;

    factory CancelTransferRequest([void updates(CancelTransferRequestBuilder b)]) = _$CancelTransferRequest;

    @BuiltValueSerializer(custom: true)
    static Serializer<CancelTransferRequest> get serializer => _$CancelTransferRequestSerializer();
}

class _$CancelTransferRequestSerializer implements StructuredSerializer<CancelTransferRequest> {

    @override
    final Iterable<Type> types = const [CancelTransferRequest, _$CancelTransferRequest];
    @override
    final String wireName = r'CancelTransferRequest';

    @override
    Iterable<Object> serialize(Serializers serializers, CancelTransferRequest object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
                specifiedType: const FullType(String)));
        result
            ..add(r'reason')
            ..add(serializers.serialize(object.reason,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    CancelTransferRequest deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CancelTransferRequestBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'userId':
                    result.userId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'reason':
                    result.reason = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

