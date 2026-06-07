//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/receive_transfer_line_dto.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'receive_transfer_request.g.dart';

abstract class ReceiveTransferRequest implements Built<ReceiveTransferRequest, ReceiveTransferRequestBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'lines')
    BuiltList<ReceiveTransferLineDto> get lines;

    ReceiveTransferRequest._();

    static void _initializeBuilder(ReceiveTransferRequestBuilder b) => b;

    factory ReceiveTransferRequest([void updates(ReceiveTransferRequestBuilder b)]) = _$ReceiveTransferRequest;

    @BuiltValueSerializer(custom: true)
    static Serializer<ReceiveTransferRequest> get serializer => _$ReceiveTransferRequestSerializer();
}

class _$ReceiveTransferRequestSerializer implements StructuredSerializer<ReceiveTransferRequest> {

    @override
    final Iterable<Type> types = const [ReceiveTransferRequest, _$ReceiveTransferRequest];
    @override
    final String wireName = r'ReceiveTransferRequest';

    @override
    Iterable<Object> serialize(Serializers serializers, ReceiveTransferRequest object,
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
            ..add(r'lines')
            ..add(serializers.serialize(object.lines,
                specifiedType: const FullType(BuiltList, [FullType(ReceiveTransferLineDto)])));
        return result;
    }

    @override
    ReceiveTransferRequest deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = ReceiveTransferRequestBuilder();

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
                case r'lines':
                    result.lines.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(ReceiveTransferLineDto)])) as BuiltList<ReceiveTransferLineDto>);
                    break;
            }
        }
        return result.build();
    }
}

