//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'confirm_transfer_request.g.dart';

abstract class ConfirmTransferRequest implements Built<ConfirmTransferRequest, ConfirmTransferRequestBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    ConfirmTransferRequest._();

    static void _initializeBuilder(ConfirmTransferRequestBuilder b) => b;

    factory ConfirmTransferRequest([void updates(ConfirmTransferRequestBuilder b)]) = _$ConfirmTransferRequest;

    @BuiltValueSerializer(custom: true)
    static Serializer<ConfirmTransferRequest> get serializer => _$ConfirmTransferRequestSerializer();
}

class _$ConfirmTransferRequestSerializer implements StructuredSerializer<ConfirmTransferRequest> {

    @override
    final Iterable<Type> types = const [ConfirmTransferRequest, _$ConfirmTransferRequest];
    @override
    final String wireName = r'ConfirmTransferRequest';

    @override
    Iterable<Object> serialize(Serializers serializers, ConfirmTransferRequest object,
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
        return result;
    }

    @override
    ConfirmTransferRequest deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = ConfirmTransferRequestBuilder();

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
            }
        }
        return result.build();
    }
}

