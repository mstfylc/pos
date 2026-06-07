//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'reason_request.g.dart';

abstract class ReasonRequest implements Built<ReasonRequest, ReasonRequestBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'reason')
    String get reason;

    ReasonRequest._();

    static void _initializeBuilder(ReasonRequestBuilder b) => b;

    factory ReasonRequest([void updates(ReasonRequestBuilder b)]) = _$ReasonRequest;

    @BuiltValueSerializer(custom: true)
    static Serializer<ReasonRequest> get serializer => _$ReasonRequestSerializer();
}

class _$ReasonRequestSerializer implements StructuredSerializer<ReasonRequest> {

    @override
    final Iterable<Type> types = const [ReasonRequest, _$ReasonRequest];
    @override
    final String wireName = r'ReasonRequest';

    @override
    Iterable<Object> serialize(Serializers serializers, ReasonRequest object,
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
    ReasonRequest deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = ReasonRequestBuilder();

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

